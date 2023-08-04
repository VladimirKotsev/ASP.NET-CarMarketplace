namespace CarMarketplace.Services
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Web.ViewModels.Catalog;
    using System;

    public class CatalogService : ICatalogService
    {
        private readonly CarMarketplaceDbContext dbContext;

        public CatalogService(CarMarketplaceDbContext _dbContext)
        {
            this.dbContext = _dbContext;   
        }

        public async Task<ICollection<SalePostViewModel>> GetLatestSalePostsAsync()
        {
            ICollection<SalePostViewModel> lastPosts = await this.dbContext
                .SalePosts
                .OrderBy(sp => sp.PublishDate)
                .Take(6)
                .Select(sp => new SalePostViewModel() 
                {
                    Car = new CarViewModel() 
                    {
                        CarName = sp.Car.Make.Name + " " + sp.Car.Model.ModelName,
                        Make = sp.Car.Make.Name,
                        Model = sp.Car.Model.ModelName,
                        Category = sp.Car.Category.Name,
                        Description = sp.Car.Description,
                        TechnicalSpecificationURL = sp.Car.TechnicalSpecificationURL,
                        Color = sp.Car.Color.Name,
                        EuroStandart = sp.Car.EuroStandart,
                        Odometer = sp.Car.Odometer,
                        Province = sp.Car.Province.ProvinceName,
                        VinNumber = sp.Car.VinNumber,
                        TransmissionType = sp.Car.TransmissionType,
                        Year = sp.Car.Year,
                        Engine = new EngineViewModel() 
                        {
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
                .ToArrayAsync();

            return lastPosts;
        }

        public async Task<ICollection<CarModelViewModel>> GetModelsByMakeAsync(string make)
        {
            var models = await this.dbContext
                .Models
                .Select(m => new CarModelViewModel()
                {
                    Id = m.Id,
                    ModelName = m.ModelName
                })
                .ToArrayAsync();

            return models;
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
                        CarName = sp.Car.Make.Name + " " + sp.Car.Model.ModelName,
                        Make = sp.Car.Make.Name,
                        Model = sp.Car.Model.ModelName,
                        Category = sp.Car.Category.Name,
                        Description = sp.Car.Description,
                        TechnicalSpecificationURL = sp.Car.TechnicalSpecificationURL,
                        Color = sp.Car.Color.Name,
                        EuroStandart = sp.Car.EuroStandart,
                        Odometer = sp.Car.Odometer,
                        Province = sp.Car.Province.ProvinceName,
                        City = sp.Car.City,
                        VinNumber = sp.Car.VinNumber,
                        TransmissionType = sp.Car.TransmissionType,
                        Year = sp.Car.Year,
                        Engine = new EngineViewModel()
                        {
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
        public async Task<SearchViewModel> GetSearchViewModelAsync()
        {
            SearchViewModel model = new SearchViewModel();

            model.Makes = await this.dbContext
                .Manufacturers
                .Select(m => new CarManufacturerViewModel()
                {
                    Id = m.Id,
                    Name = m.Name
                })
                .OrderBy(m => m.Name)
                .ToArrayAsync();

            model.Models = await this.dbContext
                .Models
                .Select(m => new CarModelViewModel()
                {
                    Id = m.Id,
                    ModelName = m.ModelName,
                    ManufacturerName = m.ManufacturerName
                })
                .OrderBy(m => m.ModelName)
                .ToArrayAsync();

            model.Categories = await this.dbContext
                .Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            model.Provinces = await this.dbContext
                .Provinces
                .Select(p => new ProvinceViewModel()
                {
                    Id = p.Id,
                    ProvinceName = p.ProvinceName,
                })
                .ToArrayAsync();

            return model;
        }
    }
}
