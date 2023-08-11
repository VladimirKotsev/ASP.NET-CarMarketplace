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

        [Test]
        public async Task DeletePostShouldDeletePost()
        {
            var postId = Guid.Parse("d094d27a-1aa4-4bff-b59b-1878c472960d");

            await this.SalePostService.DeletePostAsync(postId);
            Assert.IsFalse(await this.dbContext.SalePosts.AnyAsync(x => x.Id == postId));
        }

        [Test]
        public async Task DeletePostShouldNotDeletePost()
        {
            var validPostId = Guid.Parse("d094d27a-1aa4-4bff-b59b-1878c472960d");
            var postId = Guid.Parse("d094d27a-1aa4-4bff-b59b-1878c494960d");

            await this.SalePostService.DeletePostAsync(postId);
            Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Id == validPostId));
        }
    }
}
