using CarMarketplace.Services.Contracts;

namespace CarMarketplace.Services
{
    using CarMarketplace.Data;
    public class BecomeSellerService : IBecomeSellerService
    {
        private readonly CarMarketplaceDbContext dbContext;
        public BecomeSellerService(CarMarketplaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool IsUserASeller(string userId)
        {
            var isUserASeller = dbContext
                .Sellers
                .Any(s => s.UserId.ToString() == userId);

            return isUserASeller;
        }
    }
}