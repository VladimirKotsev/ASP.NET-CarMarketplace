﻿namespace CarMarketplace.Services
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

        //private static bool IsInRange(int? value, int min, int max)
        //{
        //    return value.HasValue && value >= min && value <= max;
        //}
        //private static Func<SalePostViewModel, bool> CreateRangeFilter(int? minValue, int? maxValue, Func<SalePostViewModel, int> propertySelector)
        //{
        //    return p => (!minValue.HasValue || propertySelector(p) >= minValue.Value) &&
        //                (!maxValue.HasValue || propertySelector(p) <= maxValue.Value);
        //}

        //private static Func<SalePostViewModel, bool> CreatePriceFilter(SearchViewModel model)
        //{
        //    return CreateRangeFilter(model.FromPrice, model.ToPrice, p => p.Price);
        //}

        //private static Func<SalePostViewModel, bool> CreateHorsepowerFilter(SearchViewModel model)
        //{
        //    return CreateRangeFilter(model.FromHorsepower, model.ToHorsepower, p => p.Car.Engine.Horsepower);
        //}

        //private static Func<SalePostViewModel, bool> CreateKilometersFilter(SearchViewModel model)
        //{
        //    return CreateRangeFilter(model.FromKilometers, model.ToKilometers, p => p.Car.Odometer);
        //}

        //private static Func<SalePostViewModel, bool> CreateYearFilter(SearchViewModel model)
        //{
        //    return CreateRangeFilter(model.FromYear, model.ToYear, p => p.Car.Year);
        //}

        //private static ICollection<SalePostViewModel> FilterPosts(ICollection<SalePostViewModel> posts, SearchViewModel model)
        //{
        //    var priceFilter = CreatePriceFilter(model);
        //    var horsepowerFilter = CreateHorsepowerFilter(model);
        //    var kilometersFilter = CreateKilometersFilter(model);
        //    var yearFilter = CreateYearFilter(model);

        //    return posts.Where(p =>
        //        (model.Make == null || p.Car.Make.Id == model.Make) &&
        //        (model.ModelName == null || p.Car.Model.ModelName == model.ModelName) &&
        //        priceFilter(p) &&
        //        horsepowerFilter(p) &&
        //        kilometersFilter(p) &&
        //        yearFilter(p) &&
        //        (model.EngineFuelType == null || model.EngineFuelType == "0" || p.Car.Engine.FuelType == model.EngineFuelType) &&
        //        (model.TransmissionType == null || model.TransmissionType == "0" || p.Car.TransmissionType == model.TransmissionType) &&
        //        (model.Category == null || model.Category == 0 || p.Car.Category.Id == model.Category))
        //    .ToList();
        //}

        private static ICollection<SalePostViewModel> FilterPosts(ICollection<SalePostViewModel> posts, SearchViewModel model)
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
                .OrderBy(sp => sp.Car.Manufacturer.Name)
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

            posts = FilterPosts(posts, model);

            int postsCount = posts.Count;

            posts = posts
                .Skip(pageNum * 3)
                .Take(3)
                .ToArray();

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

        public async Task<CatalogViewModel> GetSalePostsByNationAsync(string group, int pageNum)
        {
            ICollection<SalePostViewModel> actualPosts = new HashSet<SalePostViewModel>();

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

                actualPosts = await this.dbContext
                    .SalePosts
                    .Where(sp => brands.Contains(sp.Car.Manufacturer.Name) && sp.IsDeleted == false)
                    .OrderBy(sp => sp.Car.Manufacturer.Name)
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

                actualPosts = await this.dbContext
                    .SalePosts
                    .Where(sp => brands.Contains(sp.Car.Manufacturer.Name) && sp.IsDeleted == false)
                    .OrderBy(sp => sp.Car.Manufacturer.Name)
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

                actualPosts = await this.dbContext
                    .SalePosts
                    .Where(sp => brands.Contains(sp.Car.Manufacturer.Name) && sp.IsDeleted == false)
                    .OrderBy(sp => sp.Car.Manufacturer.Name)
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

            int postsCount = actualPosts.Count;

            var posts = actualPosts
                 .Skip(pageNum * 3)
                 .Take(3)
                 .ToArray();

            var catalogModel = new CatalogViewModel()
            {
                CurrentPage = pageNum + 1,
                PageCount = (int)Math.Ceiling((decimal)postsCount / 3),
                SalePosts = posts
            };

            return catalogModel;
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
