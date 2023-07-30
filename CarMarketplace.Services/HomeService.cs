namespace CarMarketplace.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Home;

    public class HomeService : IHomeService
    {
        private readonly CarMarketplaceDbContext dbContext;
        public HomeService(CarMarketplaceDbContext _dbContext) 
        {
            this.dbContext = _dbContext;
        }
        public async Task<ICollection<CarCardViewModel>> GetSalePostsAsync()
        {
            ICollection<CarCardViewModel> lastPosts = await this.dbContext
                .SalePosts
                .OrderBy(p => p.PublishDate)
                .Take(6)
                .Select(p => new CarCardViewModel()
                {
                    Id = p.Id,
                    CarMake = p.Car.Make.Name,
                    CarModel = p.Car.Model.ModelName,
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
