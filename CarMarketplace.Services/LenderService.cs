namespace CarMarketplace.Services
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Data;
    using CarMarketplace.Web.ViewModels.User;
    using CarMarketplace.Data.Models;

    public class LenderService : ILenderService
    {
        private readonly CarMarketplaceDbContext dbContext;
        public LenderService(CarMarketplaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> LenderExistbyPhoneNumberAsync(string phoneNumber)
        {
            bool result = await dbContext
                .Lenders
                .AnyAsync(s => s.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> LenderExistbyUserIdAsync(string userId)
        {
            bool result = await dbContext
                .Lenders
                .AnyAsync(a => a.UserId.ToString() == userId);

            return result;
        }

        public async Task RegisterUserAsLenderAsync(string userId, UserPersonalnfoViewModel model)
        {
            var lender = new Lender()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };

            await this.dbContext
                .Lenders
                .AddAsync(lender);

            await this.dbContext.SaveChangesAsync();
        }
    }
}