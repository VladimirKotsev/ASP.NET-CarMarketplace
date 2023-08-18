namespace CarMarketplace.Services
{
    using CarMarketplace.Data;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.Lender;
    using CarMarketplace.Web.ViewModels.RentPosts;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class LenderService : ILenderService
    {
        private readonly CarMarketplaceDbContext dbContext;

        public LenderService(CarMarketplaceDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }


        public async Task<Guid> GetLenderIdByUserIdAsync(string userId)
        {
            var lender = await this.dbContext
                .Lenders
                .FirstAsync(x => x.UserId == Guid.Parse(userId));

            return lender.Id;
        }

        public async Task<ICollection<RentPostViewModel>> GetLenderPostsAsync(Guid lenderId)
        {
            var posts = await this.dbContext
                .RentPosts
                .Where(rp => rp.LenderId == lenderId)
                .Select(rp => new RentPostViewModel()
                {
                    Car = new RentCarViewModel()
                    {
                        Id = rp.CarId,
                        Make = AutoMapperConfig.MapperInstance.Map<CarManufacturerViewModel>(rp.Car.Manufacturer),
                        Model = AutoMapperConfig.MapperInstance.Map<CarModelViewModel>(rp.Car.Model),
                        Category = AutoMapperConfig.MapperInstance.Map<CategoryViewModel>(rp.Car.Category),
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
                    CreatedOn = rp.CreatedOn,
                    IsRented = rp.IsRented
                })
                .ToArrayAsync();

            return posts;
        }

        public async Task<bool> LenderExistbyPhoneNumberAsync(string phoneNumber)
        {
            bool result = await dbContext
                .Lenders
                .AnyAsync(l => l.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> LenderExistbyUserIdAsync(string userId)
        {
            bool result = await dbContext
                .Lenders
                .AnyAsync(l => l.UserId.ToString() == userId);

            return result;
        }

        public async Task RegisterUserAsLenderAsync(string userId, LenderPersonalInfoViewModel model)
        {
            var city = await this.dbContext
                .Cities
                .FirstOrDefaultAsync(c => c.CityName == model.City) ?? 
                throw new ArgumentException("The provided city name does not exist");

            var lender = new Lender()
            {
                UserId = Guid.Parse(userId),
                CompanyName = model.CompanyName,
                PhoneNumber = model.PhoneNumber,
                City = city,
                CityId = city.Id,
                Address = model.Address
            };

            await this.dbContext
                .Lenders
                .AddAsync(lender);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
