namespace CarMarketplace.Services
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Data;
    using CarMarketplace.Web.ViewModels.Seller;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Web.ViewModels.Catalog;

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
                        CarName = sp.Car.Make.Name + " " + sp.Car.Model.ModelName,
                        Make = new CarManufacturerViewModel()
                        {
                            Id = sp.Car.ManufacturerId,
                            Name = sp.Car.Make.Name
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