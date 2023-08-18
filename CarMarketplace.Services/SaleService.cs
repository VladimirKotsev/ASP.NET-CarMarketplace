namespace CarMarketplace.Services
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Catalog;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Web.ViewModels.Common;
    using AutoMapper;
    using CarMarketplace.Web.ViewModels.Page;
    using CarMarketplace.Web.ViewModels.Seller;

    public class SaleService : ISaleService
    {
        private readonly CarMarketplaceDbContext dbContext;

        public SaleService(CarMarketplaceDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        private static ICollection<SalePostViewModel> FilterAllSalePosts(ICollection<SalePostViewModel> posts, SearchViewModel model)
        {
            if (model.Make != 0)
            {
                posts = posts.Where(p => p.Car.Make.Id == model.Make).ToArray();
            }
            if (model.ModelName != null)
            {
                posts = posts.Where(p => p.Car.Model.ModelName == model.ModelName).ToArray();
            }

            if (model.FromHorsepower != null && model.ToHorsepower != null)
            {
                posts = posts.Where(p => p.Car.Engine.Horsepower >= model.FromHorsepower && p.Car.Engine.Horsepower <= model.ToHorsepower).ToArray();
            }
            else if (model.FromHorsepower != null)
            {
                posts = posts.Where(p => p.Car.Engine.Horsepower >= model.FromHorsepower).ToArray();
            }
            else if (model.ToHorsepower != null)
            {
                posts = posts.Where(p => p.Car.Engine.Horsepower <= model.ToHorsepower).ToArray();
            }

            if (model.FromKilometers != null && model.ToKilometers != null)
            {
                posts = posts.Where(p => p.Car.Odometer >= model.FromKilometers && p.Car.Odometer <= model.ToKilometers).ToArray();
            }
            else if (model.FromKilometers != null)
            {
                posts = posts.Where(p => p.Car.Odometer >= model.FromKilometers).ToArray();
            }
            else if (model.ToKilometers != null)
            {
                posts = posts.Where(p => p.Car.Odometer <= model.ToKilometers).ToArray();
            }

            if (model.FromYear != null && model.ToYear != null)
            {
                posts = posts.Where(p => p.Car.Year >= model.FromYear && p.Car.Year <= model.ToYear).ToArray();
            }
            else if (model.FromYear != null)
            {
                posts = posts.Where(p => p.Car.Year >= model.FromYear).ToArray();
            }
            else if (model.ToYear != null)
            {
                posts = posts.Where(p => p.Car.Year <= model.ToYear).ToArray();
            }

            if (model.FromPrice != null && model.ToPrice != null)
            {
                posts = posts.Where(p => p.Price >= model.FromPrice && p.Price <= model.ToPrice).ToArray();
            }
            else if (model.FromPrice != null)
            {
                posts = posts.Where(p => p.Price >= model.FromPrice).ToArray();
            }
            else if (model.ToPrice != null)
            {
                posts = posts.Where(p => p.Price <= model.ToPrice).ToArray();
            }

            if (model.EngineFuelType != null && model.EngineFuelType != "0")
            {
                posts = posts.Where(p => p.Car.Engine.FuelType == model.EngineFuelType).ToArray();
            }
            if (model.TransmissionType != null && model.TransmissionType != "0")
            {
                posts = posts.Where(p => p.Car.TransmissionType == model.TransmissionType).ToArray();
            }
            if (model.Category != 0)
            {
                posts = posts.Where(p => p.Car.Category.Id == model.Category).ToArray();
            }

            return posts;
        }


        public async Task<CatalogViewModel> GetFilteredSalePostsAsync(SearchViewModel model, int pageNum)
        {
            ICollection<SalePostViewModel> posts = await this.dbContext
                .SalePosts
                .Where(sp => sp.IsDeleted == false)
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
                .AsNoTracking()
                .ToArrayAsync();

            int postsCount = posts.Count;

            posts = posts
                .Skip(pageNum * 3)
                .Take(3)
                .ToArray();

            posts = FilterAllSalePosts(posts, model);

            var catalogModel = new CatalogViewModel()
            {
                CurrentPage = pageNum + 1,
                PageCount = (int)Math.Ceiling((decimal)postsCount / 3),
                SalePosts = posts
            };

            return catalogModel;
        }

        public async Task<ICollection<SalePostViewModel>> GetLatestSalePostsAsync()
        {
            ICollection<SalePostViewModel> lastPosts = await this.dbContext
                .SalePosts
                .Where(sp => sp.IsDeleted == false)
                .OrderByDescending(sp => sp.CreatedOn)
                .Take(6)
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
                .ToArrayAsync();

            return lastPosts;
        }

        public async Task<ICollection<SalePostViewModel>> GetSalePostsByNationAsync(string group)
        {
            ICollection<SalePostViewModel> posts = new HashSet<SalePostViewModel>();

            if (group == "german")
            {
                ICollection<string> brands = new HashSet<string>
                {
                    "Audi",
                    "BMW",
                    "Mercedes-Benz",
                    "Volkswagen",
                    "Porsche",
                    "Opel",
                    "Ford",
                    "Smart"
                };

                posts = await this.dbContext
                    .SalePosts
                    .Where(sp => brands.Contains(sp.Car.Manufacturer.Name) && sp.IsDeleted == false)
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
                    .ToArrayAsync();
            }
            else if (group == "italian")
            {
                ICollection<string> brands = new HashSet<string>
                {
                    "Ferrai",
                    "Lamborghini",
                    "Alfa Romeo",
                    "Fiat",
                    "Lancia"
                };

                posts = await this.dbContext
                    .SalePosts
                    .Where(sp => brands.Contains(sp.Car.Manufacturer.Name) && sp.IsDeleted == false)
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
                    .ToArrayAsync();
            }
            else if (group == "japan")
            {
                ICollection<string> brands = new HashSet<string>
                {
                    "Toyota",
                    "Lexus",
                    "Suzuki",
                    "Mazda",
                    "Honda",
                    "Mitsubishi",
                    "Nissan",
                    "Subaru"
                };

                posts = await this.dbContext
                    .SalePosts
                    .Where(sp => brands.Contains(sp.Car.Manufacturer.Name) && sp.IsDeleted == false)
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
                    .ToArrayAsync();
            }

            return posts;
        }

        public async Task<SearchViewModel> GetSearchViewModelAsync(SearchViewModel model)
        {
            model.Makes = await this.dbContext
                .Manufacturers
                .To<CarManufacturerViewModel>()
                .OrderBy(m => m.Name)
                .ToArrayAsync();

            model.Categories = await this.dbContext
                .Categories
                .To<CategoryViewModel>()
                .ToArrayAsync();

            model.Provinces = await this.dbContext
                .Provinces
                .To<ProvinceViewModel>()
                .ToArrayAsync();

            return model;
        }
    }
}
