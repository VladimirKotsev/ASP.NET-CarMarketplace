namespace CarMarketplace.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Web.ViewModels.Catalog;
    using CarMarketplace.Services.Data.Contracts;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.SalePost;

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
                .Select(m => new CarManufacturerViewModel()
                {
                    Id = m.Id,
                    Name = m.Name
                })
                .OrderBy(m => m.Name)
                .ToArrayAsync();
        }
        private async Task<ICollection<ColorViewModel>> GetAllColorsAsViewModelsAsync()
        {
            return await this.dbContext
                .Colors
                .Select(c => new ColorViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .OrderBy(c => c.Name)
                .ToArrayAsync();
        }
        private async Task<ICollection<CategoryViewModel>> GetAllCategoriesAsViewModelAsync()
        {
            return await this.dbContext
                .Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();
        }
        private async Task<ICollection<ProvinceViewModel>> GetAllProvincesAsViewModelAsync()
        {
            return await this.dbContext
                .Provinces
                .Select(p => new ProvinceViewModel()
                {
                    Id = p.Id,
                    ProvinceName = p.ProvinceName,
                })
                .ToArrayAsync();
        }



        public async Task<SalePostViewModel> GetSalePostByIdAsync(Guid postId)
        {
            var postById = await this.dbContext
                .SalePosts
                .Where(x => x.Id == postId)
                .Select(sp => new SalePostViewModel()
                {
                    Car = new CarViewModel()
                    {
                        Make = new CarManufacturerViewModel()
                        {
                            Id = sp.Car.ManufacturerId,
                            Name = sp.Car.Manufacturer.Name
                        },
                        Model = new CarModelViewModel()
                        {
                            Id = sp.Car.ModelId,
                            ModelName = sp.Car.Model.ModelName
                        },
                        Category = new CategoryViewModel()
                        {
                            Id = sp.Car.CategoryId,
                            Name = sp.Car.Category.Name
                        },
                        Color = new ColorViewModel()
                        {
                            Id = sp.Car.ColorId,
                            Name = sp.Car.Color.Name
                        },
                        Description = sp.Car.Description,
                        TechnicalSpecificationURL = sp.Car.TechnicalSpecificationURL,
                        EuroStandart = sp.Car.EuroStandart,
                        Odometer = sp.Car.Odometer,
                        Province = new ProvinceViewModel()
                        {
                            Id = sp.Car.ProvinceId,
                            ProvinceName = sp.Car.Province.ProvinceName
                        },
                        City = sp.Car.City,
                        VinNumber = sp.Car.VinNumber,
                        TransmissionType = sp.Car.TransmissionType,
                        Year = sp.Car.Year,
                        Engine = new EngineViewModel()
                        {
                            Id = sp.Car.EngineId,
                            Displacement = sp.Car.Engine.Displacement,
                            Horsepower = sp.Car.Engine.Horsepower,
                            FuelType = sp.Car.Engine.FuelType
                        }
                    },
                    Seller = new SellerViewModel()
                    {
                        FirstName = sp.Seller.FirstName,
                        LastName = sp.Seller.LastName,
                        PhoneNumber = sp.Seller.PhoneNumber
                    },
                    PublishDate = sp.PublishDate,
                    ImageUrls = sp.ImageUrls,
                    Price = sp.Price,
                    Id = sp.Id
                })
                .FirstAsync();

            return postById;

        }

        public async Task DeletePostAsync(Guid postId)
        {
            var post = await this.dbContext
                .SalePosts
                .FirstAsync(p => p.Id == postId);

            this.dbContext.SalePosts.Remove(post);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddViewModel> GetAddPostViewModelAsync(AddViewModel viewModel)
        {
            viewModel.Makes = await GetAllMakesAsViewModelsAsync();

            viewModel.Colors = await GetAllColorsAsViewModelsAsync();

            viewModel.Categories = await GetAllCategoriesAsViewModelAsync();

            viewModel.Provinces = await GetAllProvincesAsViewModelAsync();

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

            Province province = await this.dbContext
                .Provinces
                .FirstAsync(p => p.Id == viewModel.ProvinceId);

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

            Car car = new()
            {
                Manufacturer = make,
                Model = model,
                Color = color,
                Province = province,
                Category = category,
                Engine = engine,
                City = viewModel.City,
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

            car.Seller = seller;
            car.SellerId = sellerId;

            var imagePublicIds = new HashSet<string>();

            foreach (var image in viewModel.Images)
            {
                var imageUrl = await this.mediaService.UploadPicture(image, Guid.NewGuid());
                var imageId = imageUrl.Split("upload/", StringSplitOptions.RemoveEmptyEntries)[1];
                imagePublicIds.Add(imageId);
            }

            var salePost = new SalePost()
            {
                Seller = seller,
                Car = car,
                ImageUrls = String.Join(", ", imagePublicIds.Reverse()),
                PublishDate = DateTime.Now,
                Price = viewModel.Price
            };

            await this.dbContext.Cars.AddAsync(car);
            await this.dbContext.SalePosts.AddAsync(salePost);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<EditViewModel> GetEditViewModelByPostIdAsync(EditViewModel viewModel, Guid postId)
        {
            SalePostViewModel post = await GetSalePostByIdAsync(postId);

            viewModel.Makes = await GetAllMakesAsViewModelsAsync();

            viewModel.Colors = await GetAllColorsAsViewModelsAsync();

            viewModel.Categories = await GetAllCategoriesAsViewModelAsync();

            viewModel.Provinces = await GetAllProvincesAsViewModelAsync();

            viewModel.PostId = post.Id;
            viewModel.MakeId = post.Car.Make.Id;
            viewModel.Model = post.Car.Model.ModelName;
            viewModel.ColorId = post.Car.Color.Id;
            viewModel.ProvinceId = post.Car.Province.Id;
            viewModel.CategoryId = post.Car.Category.Id;
            viewModel.City = post.Car.City;
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

            return viewModel;
            ;
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

            Province province = await this.dbContext
                .Provinces
                .FirstAsync(p => p.Id == viewModel.ProvinceId);

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

            Car carToEdit = await this.dbContext
                .Cars
                .FirstAsync(c => c.Id == postToEdit.CarId);

            carToEdit.Manufacturer = make;
            carToEdit.Engine = engine;
            carToEdit.Category = category;
            carToEdit.Color = color;
            carToEdit.Model.ModelName = viewModel.Model;
            carToEdit.Province = province;
            carToEdit.City = viewModel.City;
            carToEdit.Year = viewModel.Year;
            carToEdit.Odometer = viewModel.Odometer;
            carToEdit.TransmissionType = viewModel.TransmissionType;
            carToEdit.EuroStandart = viewModel.EuroStandart;
            carToEdit.TechnicalSpecificationURL = viewModel.TechnicalSpecificationURL;
            carToEdit.Description = viewModel.Description;
            carToEdit.VinNumber = viewModel.VinNumber;

            postToEdit.Price = viewModel.Price;
            postToEdit.PublishDate = DateTime.UtcNow;

            var imagePublicIds = new HashSet<string>();

            foreach (var image in viewModel.Images)
            {
                var imageUrl = await this.mediaService.UploadPicture(image, Guid.NewGuid());
                var imageId = imageUrl.Split("upload/", StringSplitOptions.RemoveEmptyEntries)[1];
                imagePublicIds.Add(imageId);
            }

            postToEdit.ImageUrls = String.Join(", ", imagePublicIds);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
