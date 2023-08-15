namespace CarMarketplace.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;

    using static DatabaseSeeder;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Services.Data.Contracts;
    using CarMarketplace.Services.Data;
    using CloudinaryDotNet;

    public class SalePostServiceTests
    {
        private DbContextOptions<CarMarketplaceDbContext> dbOptions;
        private CarMarketplaceDbContext dbContext;

        private ISalePostService SalePostService;
        private readonly IMediaService MediaService;

        public SalePostServiceTests()
        {

        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarMarketplaceDbContext>()
                .UseInMemoryDatabase("CarMarketplaceInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new CarMarketplaceDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.SalePostService = new SalePostService(this.dbContext, MediaService);
        }
    }
}
