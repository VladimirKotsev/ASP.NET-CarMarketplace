namespace CarMarketplace.Services
{
    using CarMarketplace.Data;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.Lender;
    using CarMarketplace.Web.ViewModels.Rent;
    using CarMarketplace.Web.ViewModels.RentPosts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RentService : IRentService
    {
        private readonly CarMarketplaceDbContext dbContext;

        public RentService(CarMarketplaceDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<RentingViewModel> GetRentingPostViewModel(Guid id, string userEmail)
        {
            var post = await this.dbContext
                .RentPosts
                .Select(rp => new RentPostViewModel()
                {
                    Car = new RentCarViewModel()
                    {
                        Make = AutoMapperConfig.MapperInstance.Map<CarManufacturerViewModel>(rp.Car.Manufacturer),
                        Model = AutoMapperConfig.MapperInstance.Map<CarModelViewModel>(rp.Car.Model),
                        Category = AutoMapperConfig.MapperInstance.Map<CategoryViewModel>(rp.Car.Category),
                        Color = AutoMapperConfig.MapperInstance.Map<ColorViewModel>(rp.Car.Color),
                        BootCapacity = rp.Car.BootCapacity,
                        Seats = rp.Car.Seats,
                        EuroStandart = rp.Car.EuroStandart,
                        TransmissionType = rp.Car.TransmissionType,
                        Year = rp.Car.Year,
                        Engine = AutoMapperConfig.MapperInstance.Map<EngineViewModel>(rp.Car.Engine)
                    },
                    Lender = new LenderViewModel()
                    {
                        Id = rp.LenderId,
                        PhoneNumber = rp.Lender.PhoneNumber,
                        CompanyName = rp.Lender.CompanyName,
                        City = new CityViewModel()
                        {
                            Province = AutoMapperConfig.MapperInstance.Map<ProvinceViewModel>(rp.Lender.City.Province),
                            CityName = rp.Lender.City.CityName,
                            CityId = rp.Lender.CityId
                        },
                        Address = rp.Lender.Address
                    },
                    ImagePublicId = rp.ImagePublicId,
                    PricePerDay = rp.PricePerDay,
                    Id = rp.Id,
                    IsRented = rp.IsRented
                })
                .FirstAsync(rp => rp.Id == id);

            var model = new RentingViewModel()
            {
                Post = post,
                Email = userEmail,
                PickUpDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(1)
            };

            return model;
        }

        public async Task RentVehicleAsync(string userId, Guid postId)
        {
            var user = await this.dbContext
                .ApplicationUsers
                .FirstAsync(x => x.Id == Guid.Parse(userId));

            var post = await this.dbContext
                .RentPosts
                .FirstAsync(x => x.Id == postId);

            var rented = new Rented()
            {
                ClientId = Guid.Parse(userId),
                Client = user,
                PostId = postId,
                RentPost = post
            };

            post.IsRented = true;

            await this.dbContext.Rents.AddAsync(rented);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<RentPostViewModel>> GetRentPostViewModelAsync()
        {
            ICollection<RentPostViewModel> rentPosts = await this.dbContext
                .RentPosts
                .Where(rp => rp.IsRented == false)
                .Select(rp => new RentPostViewModel()
                {
                    Car = new RentCarViewModel()
                    {
                        Make = AutoMapperConfig.MapperInstance.Map<CarManufacturerViewModel>(rp.Car.Manufacturer),
                        Model = AutoMapperConfig.MapperInstance.Map<CarModelViewModel>(rp.Car.Model),
                        Category = AutoMapperConfig.MapperInstance.Map<CategoryViewModel>(rp.Car.Category),
                        Color = AutoMapperConfig.MapperInstance.Map<ColorViewModel>(rp.Car.Color),
                        BootCapacity = rp.Car.BootCapacity,
                        Seats = rp.Car.Seats,
                        EuroStandart = rp.Car.EuroStandart,
                        TransmissionType = rp.Car.TransmissionType,
                        Year = rp.Car.Year,
                        Engine = AutoMapperConfig.MapperInstance.Map<EngineViewModel>(rp.Car.Engine)
                    },
                    Lender = new LenderViewModel()
                    {
                        Id = rp.LenderId,
                        PhoneNumber = rp.Lender.PhoneNumber,
                        CompanyName = rp.Lender.CompanyName,
                        City = new CityViewModel()
                        {
                            Province = AutoMapperConfig.MapperInstance.Map<ProvinceViewModel>(rp.Lender.City.Province),
                            CityName = rp.Lender.City.CityName,
                            CityId = rp.Lender.CityId
                        },
                        Address = rp.Lender.Address
                    },
                    ImagePublicId = rp.ImagePublicId,
                    PricePerDay = rp.PricePerDay,
                    Id = rp.Id,
                    IsRented = rp.IsRented
                })
                .ToArrayAsync();

            return rentPosts;
        }
    }
}
