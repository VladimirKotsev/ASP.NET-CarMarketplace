namespace CarMarketplace.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Data.Contracts;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.SalePost;
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Web.ViewModels.Seller;

    public class SalePostService : ISalePostService
    {
        private readonly CarMarketplaceDbContext dbContext;
        private readonly IMediaService mediaService;

        public SalePostService(CarMarketplaceDbContext _dbContext, IMediaService _mediaService)
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
        private async Task<ICollection<ColorViewModel>> GetAllColorsAsViewModelsAsync()
        {
            return await this.dbContext
                .Colors
                .To<ColorViewModel>()
                .OrderBy(c => c.Name)
                .ToArrayAsync();
        }
        private async Task<ICollection<CategoryViewModel>> GetAllCategoriesAsViewModelAsync()
        {
            return await this.dbContext
                .Categories
                .To<CategoryViewModel>()
                .ToArrayAsync();
        }



        public async Task<SalePostViewModel> GetSalePostByIdAsync(Guid postId)
        {
            var postById = await this.dbContext
                .SalePosts
                .Where(x => x.Id == postId)
                .Select(sp => new SalePostViewModel()
                {
                    Car = new SaleCarViewModel()
                    {
                        Make = AutoMapperConfig.MapperInstance.Map<CarManufacturerViewModel>(sp.Car.Manufacturer),
                        Model = AutoMapperConfig.MapperInstance.Map<CarModelViewModel>(sp.Car.Model),
                        Category = AutoMapperConfig.MapperInstance.Map<CategoryViewModel>(sp.Car.Category),
                        Color = AutoMapperConfig.MapperInstance.Map<ColorViewModel>(sp.Car.Color),
                        Description = sp.Car.Description,
                        TechnicalSpecificationURL = sp.Car.TechnicalSpecificationURL,
                        EuroStandart = sp.Car.EuroStandart,
                        Odometer = sp.Car.Odometer,
                        VinNumber = sp.Car.VinNumber,
                        TransmissionType = sp.Car.TransmissionType,
                        Year = sp.Car.Year,
                        Engine = AutoMapperConfig.MapperInstance.Map<EngineViewModel>(sp.Car.Engine)
                    },
                    Seller = new SellerViewModel()
                    {
                        FirstName = sp.Seller.FirstName,
                        LastName = sp.Seller.LastName,
                        PhoneNumber = sp.Seller.PhoneNumber,
                        City = new CityViewModel()
                        {
                            CityName = sp.Seller.City.CityName,
                            Province = AutoMapperConfig.MapperInstance.Map<ProvinceViewModel>(sp.Seller.City.Province)
                        }
                    },
                    CreatedOn = sp.CreatedOn,
                    IsDeleted = sp.IsDeleted,
                    ThumbnailImage = sp.ThumbnailImagePublicId,
                    ImageUrls = sp.ImagePublicIds,
                    Price = sp.Price,
                    Id = sp.Id
                })
                .FirstAsync();

            return postById;

        }
        public async Task DeletePostAsync(Guid postId, Guid carId)
        {
            var post = await this.dbContext
                .SalePosts
                .FirstAsync(p => p.Id == postId);

            var car = await this.dbContext
                .SaleCars
                .FirstAsync(c => c.Id == carId);

            this.dbContext.SaleCars.Remove(car);
            this.dbContext.SalePosts.Remove(post);
            await this.dbContext.SaveChangesAsync();
        }
        public async Task<AddViewModel> GetAddPostViewModelAsync(AddViewModel viewModel)
        {
            viewModel.Makes = await GetAllMakesAsViewModelsAsync();

            viewModel.Colors = await GetAllColorsAsViewModelsAsync();

            viewModel.Categories = await GetAllCategoriesAsViewModelAsync();

            return viewModel;
        }
        public async Task AddPostAsync(AddViewModel viewModel, Guid sellerId)
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

            Color color = await this.dbContext
                .Colors
                .FirstAsync(c => c.Id == viewModel.ColorId);

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

            SaleCar car = new()
            {
                Manufacturer = make,
                Model = model,
                Color = color,
                Category = category,
                Engine = engine,
                Description = viewModel.Description,
                VinNumber = viewModel.VinNumber,
                TechnicalSpecificationURL = viewModel.TechnicalSpecificationURL,
                EuroStandart = viewModel.EuroStandart,
                Odometer = viewModel.Odometer,
                TransmissionType = viewModel.TransmissionType,
                Year = viewModel.Year,
            };

            Seller seller = await this.dbContext
                .Sellers
                .FirstAsync(x => x.Id == sellerId);

            var imagePublicIds = new HashSet<string>();

            if (viewModel.Images!.Count > 0)
            {

                foreach (var image in viewModel.Images)
                {
                    var imageUrl = await this.mediaService.UploadPictureAsync(image, Guid.NewGuid());
                    var imageId = imageUrl.Split("upload/", StringSplitOptions.RemoveEmptyEntries)[1];
                    imagePublicIds.Add(imageId);
                }
            }

            var thumbnailImageUrl = await this.mediaService.UploadPictureAsync(viewModel.ThumbnailImage, Guid.NewGuid());
            var thumbnailImageId = thumbnailImageUrl.Split("upload/", StringSplitOptions.RemoveEmptyEntries)[1];

            var salePost = new SalePost()
            {
                Seller = seller,
                Car = car,
                CarId = car.Id,
                ThumbnailImagePublicId = thumbnailImageId,
                ImagePublicIds = String.Join(", ", imagePublicIds),
                CreatedOn = DateTime.Now,
                Price = viewModel.Price
            };

            await this.dbContext.SaleCars.AddAsync(car);
            await this.dbContext.SalePosts.AddAsync(salePost);
            await this.dbContext.SaveChangesAsync();
        }
        public async Task<EditViewModel> GetEditViewModelByPostIdAsync(EditViewModel viewModel, Guid postId)
        {
            SalePostViewModel post = await GetSalePostByIdAsync(postId);

            viewModel.Makes = await GetAllMakesAsViewModelsAsync();

            viewModel.Colors = await GetAllColorsAsViewModelsAsync();

            viewModel.Categories = await GetAllCategoriesAsViewModelAsync();

            viewModel.PostId = post.Id;
            viewModel.MakeId = post.Car.Make.Id;
            viewModel.Model = post.Car.Model.ModelName;
            viewModel.ColorId = post.Car.Color.Id;
            viewModel.CategoryId = post.Car.Category.Id;
            viewModel.Year = post.Car.Year;
            viewModel.EngineDisplacement = post.Car.Engine.Displacement;
            viewModel.EngineFuelType = post.Car.Engine.FuelType;
            viewModel.EngineHorsePower = post.Car.Engine.Horsepower;
            viewModel.Odometer = post.Car.Odometer;
            viewModel.TransmissionType = post.Car.TransmissionType;
            viewModel.EuroStandart = post.Car.EuroStandart;
            viewModel.TechnicalSpecificationURL = post.Car.TechnicalSpecificationURL;
            viewModel.VinNumber = post.Car.VinNumber;
            viewModel.Description = post.Car.Description;
            viewModel.Price = post.Price;
            viewModel.ImageUrls = post.ImageUrls;
            viewModel.ThumbnailImageUrl = post.ThumbnailImage;

            return viewModel;
        }
        public async Task EditPostByIdAsync(EditViewModel viewModel)
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

            Color color = await this.dbContext
                .Colors
                .FirstAsync(c => c.Id == viewModel.ColorId);

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

            SalePost postToEdit = await this.dbContext
                .SalePosts
                .FirstAsync(sp => sp.Id == viewModel.PostId);

            SaleCar carToEdit = await this.dbContext
                .SaleCars
                .FirstAsync(c => c.Id == postToEdit.CarId);

            carToEdit.Manufacturer = make;
            carToEdit.Engine = engine;
            carToEdit.Category = category;
            carToEdit.Color = color;
            carToEdit.Model = model;
            carToEdit.Year = viewModel.Year;
            carToEdit.Odometer = viewModel.Odometer;
            carToEdit.TransmissionType = viewModel.TransmissionType;
            carToEdit.EuroStandart = viewModel.EuroStandart;
            carToEdit.TechnicalSpecificationURL = viewModel.TechnicalSpecificationURL;
            carToEdit.Description = viewModel.Description;
            carToEdit.VinNumber = viewModel.VinNumber;

            postToEdit.Price = viewModel.Price;
            postToEdit.CreatedOn = DateTime.UtcNow;

            var imagePublicIds = new HashSet<string>();

            if (viewModel.Images.Count > 0)
            {
                foreach (var image in viewModel.Images)
                {
                    var imageUrl = await this.mediaService.UploadPictureAsync(image, Guid.NewGuid());
                    var imageId = imageUrl.Split("upload/", StringSplitOptions.RemoveEmptyEntries)[1];
                    imagePublicIds.Add(imageId);
                }
            }

            var thumbnailImageUrl = await this.mediaService.UploadPictureAsync(viewModel.ThumbnailImage, Guid.NewGuid());
            var thumbnailImageId = thumbnailImageUrl.Split("upload/", StringSplitOptions.RemoveEmptyEntries)[1];

            postToEdit.ThumbnailImagePublicId = thumbnailImageId;
            postToEdit.ImagePublicIds = String.Join(", ", imagePublicIds);

            await this.dbContext.SaveChangesAsync();
        }
        public async Task ArchivePostByIdAsync(Guid postId)
        {
            var post = await this.dbContext
                .SalePosts
                .FirstAsync(p => p.Id == postId);

            post.IsDeleted = true;
            await this.dbContext.SaveChangesAsync();
        }
    }
}
