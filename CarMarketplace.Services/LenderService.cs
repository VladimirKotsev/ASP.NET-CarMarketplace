namespace CarMarketplace.Services
{
    using CarMarketplace.Data;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Lender;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class LenderService : ILenderService
    {
        private readonly CarMarketplaceDbContext dbContext;

        public LenderService(CarMarketplaceDbContext _dbContext)
        {
            this.dbContext = _dbContext;
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
                CityId = city.Id
            };

            await this.dbContext
                .Lenders
                .AddAsync(lender);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
