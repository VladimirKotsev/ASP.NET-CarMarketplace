namespace CarMarketplace.Services
{
    using CarMarketplace.Data;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Catalog;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly CarMarketplaceDbContext dbContext;

        public UserService(CarMarketplaceDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task AddToUserFavouritesAsync(Guid postId, string userId)
        {
            var post = await this.dbContext
                .SalePosts
                .FirstAsync(sp => sp.Id == postId);

            var user = await this.dbContext
                .ApplicationUsers
                .FirstAsync(u => u.Id == Guid.Parse(userId));

            var userLikedPost = new SalePostApplicationUsers()
            {
                SalePost = post,
                User = user,
            };

            user.Favorites.Add(userLikedPost);
            post.Users.Add(userLikedPost);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<SalePostViewModel>> GetUserFavouritesAsync(string userId)
        {
            var userFavorites = await this.dbContext
                .ApplicationUsers
                .Where(u => u.Id == Guid.Parse(userId))
                .Select(a => a.Favorites)
                .FirstAsync();

            //Need to select salePosts and user, because there are null

            //var salePosts = await dbContext
            //    .SalePosts
            //    .Where(s => s.Id == userFavorites.)

            var favSalePosts = userFavorites
                .Select(f => new SalePostViewModel()
                {
                    Car = new CarViewModel()
                    {
                        Make = new CarManufacturerViewModel()
                        {
                            Id = f.SalePost.Car.ManufacturerId,
                            Name = f.SalePost.Car.Manufacturer.Name
                        },
                        Model = new CarModelViewModel()
                        {
                            Id = f.SalePost.Car.ModelId,
                            ModelName = f.SalePost.Car.Model.ModelName
                        },
                        Category = new CategoryViewModel()
                        {
                            Id = f.SalePost.Car.CategoryId,
                            Name = f.SalePost.Car.Category.Name
                        },
                        Color = new ColorViewModel()
                        {
                            Id = f.SalePost.Car.ColorId,
                            Name = f.SalePost.Car.Color.Name
                        },
                        Description = f.SalePost.Car.Description,
                        TechnicalSpecificationURL = f.SalePost.Car.TechnicalSpecificationURL,
                        EuroStandart = f.SalePost.Car.EuroStandart,
                        Odometer = f.SalePost.Car.Odometer,
                        Province = new ProvinceViewModel()
                        {
                            Id = f.SalePost.Car.ProvinceId,
                            ProvinceName = f.SalePost.Car.Province.ProvinceName
                        },
                        City = f.SalePost.Car.City,
                        VinNumber = f.SalePost.Car.VinNumber,
                        TransmissionType = f.SalePost.Car.TransmissionType,
                        Year = f.SalePost.Car.Year,
                        Engine = new EngineViewModel()
                        {
                            Id = f.SalePost.Car.EngineId,
                            Displacement = f.SalePost.Car.Engine.Displacement,
                            Horsepower = f.SalePost.Car.Engine.Horsepower,
                            FuelType = f.SalePost.Car.Engine.FuelType
                        }
                    },
                    Seller = new SellerViewModel()
                    {
                        FirstName = f.SalePost.Seller.FirstName,
                        LastName = f.SalePost.Seller.LastName,
                        PhoneNumber = f.SalePost.Seller.PhoneNumber
                    },
                    PublishDate = f.SalePost.PublishDate,
                    ImageUrls = f.SalePost.ImageUrls,
                    Price = f.SalePost.Price,
                    Id = f.SalePost.Id
                })
                .ToArray();

            return favSalePosts;
        }
    }
}
