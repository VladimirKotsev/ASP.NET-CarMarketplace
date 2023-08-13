namespace CarMarketplace.Services
{
    using Microsoft.EntityFrameworkCore;

    using Services.Contracts;
    using CarMarketplace.Data;
    using Web.ViewModels.Seller;
    using CarMarketplace.Data.Models;
    using Web.ViewModels.Common;
    using Services.Mapping;

    public class SellerService : ISellerService
    {
        private readonly CarMarketplaceDbContext dbContext;
        public SellerService(CarMarketplaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task RegisterUserAsSellerAsync(string userId, SellerPersonalInfoViewModel model)
        {
            var city = await this.dbContext
                .Cities
                .FirstAsync(c => c.CityName == model.City);

            var seller = new Seller()
            {
                UserId = Guid.Parse(userId),
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                City = city
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
                .OrderBy(sp => sp.CreatedOn)
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
                    ThumbnailImage = sp.ThumbnailImagePublicId,
                    ImageUrls = sp.ImagePublicIds,
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

        public async Task<bool> CityExistByNameAsync(string name)
        {
            return await this.dbContext
                .Cities
                .AnyAsync(c => c.CityName == name);
        }
    }
}