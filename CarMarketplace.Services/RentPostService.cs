namespace CarMarketplace.Services
{
    using System.Threading.Tasks;
    using System.Linq;

    using CarMarketplace.Data;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.RentPosts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Data.Contracts;

    public class RentPostService : IRentPostService
    {
        private readonly CarMarketplaceDbContext dbContext;
        private readonly IMediaService mediaService;

        public RentPostService(CarMarketplaceDbContext _dbContext, IMediaService _mediaService)
        {
            this.dbContext = _dbContext;
            this.mediaService = _mediaService;
        }

        private async Task<ICollection<CarManufacturerViewModel>> GetAllMakesAsViewModelsAsync()
        {
            return await this.dbContext
                .Manufacturers
                .To<CarManufacturerViewModel>()
                .OrderBy(m => m.Name)
                .ToArrayAsync();
        }
        private async Task<ICollection<CategoryViewModel>> GetAllCategoriesAsViewModelAsync()
        {
            return await this.dbContext
                .Categories
                .To<CategoryViewModel>()
                .ToArrayAsync();
        }

        public async Task<AddRentPostViewModel> GetAddViewModelAsync(AddRentPostViewModel model)
        {
            model.Makes = await GetAllMakesAsViewModelsAsync();
            model.Categories = await GetAllCategoriesAsViewModelAsync();

            return model;
        }

        public async Task AddPostAsync(AddRentPostViewModel viewModel, Guid lenderId)
        {
            Engine? engine = await this.dbContext
                .Engines
                .FirstOrDefaultAsync(e => e.Displacement == viewModel.EngineDisplacement
                && e.Horsepower == viewModel.EngineHorsePower
                && e.FuelType == viewModel.EngineFuelType);

            if (engine == null)
            {
                engine = new Engine()
                {
                    Displacement = viewModel.EngineDisplacement,
                    Horsepower = viewModel.EngineHorsePower,
                    FuelType = viewModel.EngineFuelType
                };

                await this.dbContext.Engines.AddAsync(engine);
            }

            Category category = await this.dbContext
                .Categories
                .FirstAsync(c => c.Id == viewModel.CategoryId);

            CarManufacturer make = await this.dbContext
                .Manufacturers
                .FirstAsync(m => m.Id == viewModel.MakeId);

            CarModel? model = await this.dbContext
                .Models
                .FirstOrDefaultAsync(m => m.ModelName == viewModel.Model && m.ManufacturerName == make.Name);

            if (model == null)
            {
                model = new CarModel()
                {
                    ModelName = viewModel.Model,
                    ManufacturerName = make.Name
                };

                await this.dbContext.Models.AddAsync(model);
            }

            RentCar car = new()
            {
                Manufacturer = make,
                Model = model,
                Category = category,
                Engine = engine,
                EuroStandart = viewModel.EuroStandart,
                TransmissionType = viewModel.TransmissionType,
                Year = viewModel.Year,
                BootCapacity = viewModel.BootCapacity,
                Seats = viewModel.Seats
            };

            Lender lender = await this.dbContext
                .Lenders
                .FirstAsync(x => x.Id == lenderId);

            var thumbnailImageUrl = await this.mediaService.UploadPictureAsync(viewModel.Image, Guid.NewGuid());
            var publicImageId = thumbnailImageUrl.Split("upload/", StringSplitOptions.RemoveEmptyEntries)[1];

            var rentPost = new RentPost()
            {
                Lender = lender,
                Car = car,
                CarId = car.Id,
                ImagePublicId = publicImageId,
                CreatedOn = DateTime.Now,
                PricePerDay = viewModel.PricePerDay
            };

            await this.dbContext.RentCars.AddAsync(car);
            await this.dbContext.RentPosts.AddAsync(rentPost);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeletePostAsync(Guid postId, Guid carId)
        {
            var post = await this.dbContext
                .RentPosts
                .FirstAsync(p => p.Id == postId);

            var car = await this.dbContext
                .RentCars
                .FirstAsync(c => c.Id == carId);

            this.dbContext.RentPosts.Remove(post);
            this.dbContext.RentCars.Remove(car);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
