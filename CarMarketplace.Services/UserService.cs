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

            var userLikedPost = new SalePostApplicationUser()
            {
                SalePost = post,
                User = user,
                AddedToFavourites = DateTime.UtcNow
            };

            user.Favorites.Add(userLikedPost);
            post.SalePostUsers.Add(userLikedPost);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<SalePostViewModel>> GetUserFavouritesAsync(string userId)
        {
            ICollection<SalePostViewModel> favSalePosts = new HashSet<SalePostViewModel>();

            var userFavorites = await this.dbContext
                .ApplicationUsers
                .Where(u => u.Id == Guid.Parse(userId))
                .Select(a => a.Favorites)
                .FirstAsync();

            foreach (var salePostId in userFavorites.Select(x => x.SalePostId))
            {
                var salePost = await dbContext
                    .SalePosts
                    .Select(s => new SalePostViewModel()
                    {
                        Car = new CarViewModel()
                        {
                            Make = new CarManufacturerViewModel()
                            {
                                Id = s.Car.ManufacturerId,
                                Name = s.Car.Manufacturer.Name
                            },
                            Model = new CarModelViewModel()
                            {
                                Id = s.Car.ModelId,
                                ModelName = s.Car.Model.ModelName
                            },
                            Category = new CategoryViewModel()
                            {
                                Id = s.Car.CategoryId,
                                Name = s.Car.Category.Name
                            },
                            Color = new ColorViewModel()
                            {
                                Id = s.Car.ColorId,
                                Name = s.Car.Color.Name
                            },
                            Description = s.Car.Description,
                            TechnicalSpecificationURL = s.Car.TechnicalSpecificationURL,
                            EuroStandart = s.Car.EuroStandart,
                            Odometer = s.Car.Odometer,
                            Province = new ProvinceViewModel()
                            {
                                Id = s.Car.ProvinceId,
                                ProvinceName = s.Car.Province.ProvinceName
                            },
                            City = s.Car.City,
                            VinNumber = s.Car.VinNumber,
                            TransmissionType = s.Car.TransmissionType,
                            Year = s.Car.Year,
                            Engine = new EngineViewModel()
                            {
                                Id = s.Car.EngineId,
                                Displacement = s.Car.Engine.Displacement,
                                Horsepower = s.Car.Engine.Horsepower,
                                FuelType = s.Car.Engine.FuelType
                            }
                        },
                        Seller = new SellerViewModel()
                        {
                            FirstName = s.Seller.FirstName,
                            LastName = s.Seller.LastName,
                            PhoneNumber = s.Seller.PhoneNumber
                        },
                        PublishDate = s.PublishDate,
                        ImageUrls = s.ImageUrls,
                        Price = s.Price,
                        Id = s.Id
                    })
                    .FirstAsync(s => s.Id == salePostId);

                favSalePosts.Add(salePost);
            }

            return favSalePosts;
        }

        public async Task<ICollection<Guid>> GetUserFavouritePostIdsAsync(string userId)
        {
            ICollection<Guid> postIds = new HashSet<Guid>();

            var userFavorites = await this.dbContext
                .ApplicationUsers
                .Where(u => u.Id == Guid.Parse(userId))
                .Select(a => a.Favorites)
                .FirstAsync();

            foreach (var id in userFavorites.Select(x => x.SalePostId))
            {
                postIds.Add(id);
            }

            return postIds;
        }

        public async Task RemoveUserFavouritePostAsync(Guid postId, string userId)
        {
            var post = await this.dbContext
                .SalePosts
                .FirstAsync(sp => sp.Id == postId);

            var user = await this.dbContext
                .ApplicationUsers
                .FirstAsync(u => u.Id == Guid.Parse(userId));

            var userLikedPost = new SalePostApplicationUser()
            {
                SalePost = post,
                User = user,
            };

            user.Favorites.Remove(userLikedPost);
            post.SalePostUsers.Remove(userLikedPost);
            this.dbContext.SalePostApplicationUsers.Remove(userLikedPost);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
