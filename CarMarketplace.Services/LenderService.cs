namespace CarMarketplace.Services
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Data;

    public class LenderService : ILenderService
    {
        private readonly CarMarketplaceDbContext dbContext;
        public LenderService(CarMarketplaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> LenderExistbyUserIdAsync(string userId)
        {
            bool result = await dbContext
                .Lenders
                .AnyAsync(a => a.UserId.ToString() == userId);

            return result;
        }
    }
}