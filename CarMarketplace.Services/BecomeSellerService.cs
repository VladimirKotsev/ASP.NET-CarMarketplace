namespace CarMarketplace.Services
{
    using CarMarketplace.Data;
    using CarMarketplace.Services.Contracts;

    public class BecomeSellerService : IBecomeSellerService
    {
        private readonly CarMarketplaceDbContext dbContext;
        public BecomeSellerService(CarMarketplaceDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async bool IsUserASellerAsync()
        {
            var isUserASeller = dbContext.
        }
    }
}