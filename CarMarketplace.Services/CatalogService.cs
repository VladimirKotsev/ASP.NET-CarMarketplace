namespace CarMarketplace.Services
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Catalog;

    public class CatalogService : ICatalogService
    {
        private readonly CarMarketplaceDbContext dbContext;

        public CatalogService(CarMarketplaceDbContext _dbContext)
        {
            this.dbContext = _dbContext;   
        }

        public async Task<ICollection<CarShortViewModel>> GetLatestSalePostsAsync()
        {
            ICollection<CarShortViewModel> lastPosts = await this.dbContext
                .SalePosts
                .OrderBy(p => p.PublishDate)
                .Take(6)
                .Select(p => new CarShortViewModel()
                {
                    Id = p.Id,
                    CarMake = p.Car.Make.Name,
                    CarModel = p.Car.Model.ModelName,
                    CarName = p.Car.Make.Name + " " + p.Car.Model.ModelName,
                    CarYear = p.Car.Year,
                    CarProvinceName = p.Car.Province.ProvinceName,
                    Price = p.Price,
                    MainPictureUrl = p.ImageUrls.Split(", ", StringSplitOptions.RemoveEmptyEntries).First(),
                    PublishDate = p.PublishDate
                })
                .ToArrayAsync();

            return lastPosts;
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

            return model;
        }
    }
}
