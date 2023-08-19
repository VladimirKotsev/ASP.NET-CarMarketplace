namespace CarMarketplace.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;
    using CarMarketplace.Data.Models;
    using Contracts;
    using Mapping;
    using Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.User;
    using CarMarketplace.Web.ViewModels.Seller;
    using CarMarketplace.Web.ViewModels.RentPosts;
    using CarMarketplace.Web.ViewModels.Lender;
    using AutoMapper;

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
                LikedOn = DateTime.Now
            };

            user.Favorites.Add(userLikedPost);
            post.SalePostUsers.Add(userLikedPost);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<FavouriteViewModel>> GetUserFavouritesAsync(string userId)
        {
            ICollection<FavouriteViewModel> favSalePosts = new HashSet<FavouriteViewModel>();

            var userFavorites = await this.dbContext
                .ApplicationUsers
                .Where(u => u.Id == Guid.Parse(userId))
                .Select(a => a.Favorites)
                .FirstAsync();

            foreach (var favourite in userFavorites)
            {
                var salePost = await dbContext
                    .SalePosts
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
                    .FirstAsync(s => s.Id == favourite.SalePostId);

                favSalePosts.Add(new FavouriteViewModel()
                {
                    SalePost = salePost,
                    LikedOn = favourite.LikedOn
                });
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

            var userLikedPost = await this.dbContext
                .SalePostApplicationUsers
                .FirstAsync(su => su.SalePost == post && su.User == user);

            user.Favorites.Remove(userLikedPost);
            post.SalePostUsers.Remove(userLikedPost);
            this.dbContext.SalePostApplicationUsers.Remove(userLikedPost);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> UserHasRentedVehicleAsync(string userId)
        {
            bool result = await dbContext
                .Rents
                .AnyAsync(s => s.ClientId.ToString() == userId);

            return result;
        }

        public async Task<RentedViewModel> GetUserRentedVehicleAsync(string userId)
        {
            var model = await this.dbContext
                .Rents
                .Where(x => x.ClientId == Guid.Parse(userId))
                .Select(r => new RentedViewModel()
                {
                    Car = new RentCarViewModel() 
                    {
                        Id = r.RentPost.CarId,
                        Make = AutoMapperConfig.MapperInstance.Map<CarManufacturerViewModel>(r.RentPost.Car.Manufacturer),
                        Model = AutoMapperConfig.MapperInstance.Map<CarModelViewModel>(r.RentPost.Car.Model),
                        Category = AutoMapperConfig.MapperInstance.Map<CategoryViewModel>(r.RentPost.Car.Category),
                        BootCapacity = r.RentPost.Car.BootCapacity,
                        Seats = r.RentPost.Car.Seats,
                        EuroStandart = r.RentPost.Car.EuroStandart,
                        TransmissionType = r.RentPost.Car.TransmissionType,
                        Year = r.RentPost.Car.Year,
                        Engine = AutoMapperConfig.MapperInstance.Map<EngineViewModel>(r.RentPost.Car.Engine)
                    },
                    Lender = new LenderViewModel()
                    {
                        Id = r.RentPost.LenderId,
                        PhoneNumber = r.RentPost.Lender.PhoneNumber,
                        CompanyName = r.RentPost.Lender.CompanyName,
                        City = new CityViewModel()
                        {
                            Province = AutoMapperConfig.MapperInstance.Map<ProvinceViewModel>(r.RentPost.Lender.City.Province),
                            CityName = r.RentPost.Lender.City.CityName,
                            CityId = r.RentPost.Lender.CityId
                        },
                        Address = r.RentPost.Lender.Address
                    },
                    ImagePublicId = r.RentPost.ImagePublicId,
                    PricePerDay = r.RentPost.PricePerDay,
                    Id = r.RentPost.Id,
                    FullName = r.FullName,
                    Email = r.Email,
                    PhoneNumber = r.PhoneNumber,
                    PickUpDate = r.PickUpDate,
                    ReturnDate = r.ReturnDate
                })
                .FirstAsync();

            return model;
        }

        public async Task ReturnRentedCarAsync(Guid postId, string userId)
        {
            var post = await this.dbContext
                .RentPosts
                .FirstAsync(x => x.Id == postId);

            var user = await this.dbContext
                .ApplicationUsers
                .FirstAsync(x => x.Id == Guid.Parse(userId));

            var rented = await this.dbContext
                .Rents
                .FirstAsync(r => r.PostId == postId && r.ClientId == Guid.Parse(userId));

            this.dbContext.Rents.Remove(rented);
            post.IsRented = false;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
