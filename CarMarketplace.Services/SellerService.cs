namespace CarMarketplace.Services
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Data;
    using CarMarketplace.Web.ViewModels.User;
    using CarMarketplace.Data.Models;

    public class SellerService : ISellerService
    {
        private readonly CarMarketplaceDbContext dbContext;
        public SellerService(CarMarketplaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task RegisterUserAsSellerAsync(string userId, UserPersonalnfoViewModel model)
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
    }
}