namespace CarMarketplace.Services
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Home;

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
    }
}
