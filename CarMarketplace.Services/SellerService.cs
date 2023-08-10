namespace CarMarketplace.Services
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Data;
    using CarMarketplace.Web.ViewModels.Seller;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Web.ViewModels.Catalog;
    using CarMarketplace.Web.ViewModels;
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Services.Mapping;

    public class SellerService : ISellerService
    {
        private readonly CarMarketplaceDbContext dbContext;
        public SellerService(CarMarketplaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task RegisterUserAsSellerAsync(string userId, SellerPersonalnfoViewModel model)
        {
            var seller = new Seller()
            {
                UserId = Guid.Parse(userId),
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };

            await this.dbContext
                .Sellers
                .AddAsync(seller);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> SellerExistbyPhoneNumberAsync(string phoneNumber)
        {
            bool result = await dbContext
                .Sellers
                .AnyAsync(s => s.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> SellerExistbyUserIdAsync(string userId)
        {
            bool result = await dbContext
                .Sellers
                .AnyAsync(s => s.UserId.ToString() == userId);

            return result;
        }

        public async Task<ICollection<SalePostViewModel>> GetSellerPostsAsync(Guid sellerId)
        {
            ICollection<SalePostViewModel> sellerPosts = await this.dbContext
                .SalePosts
                .Where(x => x.SellerId == sellerId)
                .OrderBy(sp => sp.PublishDate)
                .Select(sp => new SalePostViewModel()
                {
                    Car = new CarViewModel()
                    {
                        Make = AutoMapperConfig.MapperInstance.Map<CarManufacturerViewModel>(sp.Car.Manufacturer),
                        Model = AutoMapperConfig.MapperInstance.Map<CarModelViewModel>(sp.Car.Model),
                        Category = AutoMapperConfig.MapperInstance.Map<CategoryViewModel>(sp.Car.Category),
                        Color = AutoMapperConfig.MapperInstance.Map<ColorViewModel>(sp.Car.Color),
                        Description = sp.Car.Description,
                        TechnicalSpecificationURL = sp.Car.TechnicalSpecificationURL,
                        EuroStandart = sp.Car.EuroStandart,
                        Odometer = sp.Car.Odometer,
                        Province = AutoMapperConfig.MapperInstance.Map<ProvinceViewModel>(sp.Car.Province),
                        City = sp.Car.City,
                        VinNumber = sp.Car.VinNumber,
                        TransmissionType = sp.Car.TransmissionType,
                        Year = sp.Car.Year,
                        Engine = AutoMapperConfig.MapperInstance.Map<EngineViewModel>(sp.Car.Engine)
                    },
                    Seller = AutoMapperConfig.MapperInstance.Map<SellerViewModel>(sp.Car.Seller),
                    PublishDate = sp.PublishDate,
                    ImageUrls = sp.ImageUrls,
                    Price = sp.Price,
                    Id = sp.Id
                })
                .ToArrayAsync();

            return sellerPosts;
        }

        public async Task<Guid> GetSellerIdByUserIdAsync(string userId)
        {
            var seller = await this.dbContext
                .Sellers
                .FirstAsync(s => s.UserId == Guid.Parse(userId));

            return seller.Id;
        }
    }
}