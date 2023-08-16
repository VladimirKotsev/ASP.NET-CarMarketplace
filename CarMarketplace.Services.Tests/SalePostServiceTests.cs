namespace CarMarketplace.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;

    using static DatabaseSeeder;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Services.Data.Contracts;
    using CarMarketplace.Services.Data;
    using CloudinaryDotNet;
    using System.Security.Cryptography.X509Certificates;
    using CarMarketplace.Web.ViewModels.SalePost;
    using Microsoft.AspNetCore.Http;

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
        public async Task GetSalePostByIdShouldReturnCorrectPost()
        {
            var postId = Guid.Parse("d094d27a-1aa4-4bff-b59b-1878c472960d");

            var post = await SalePostService.GetSalePostByIdAsync(postId);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(post);
                Assert.That(postId, Is.EqualTo(post.Id));
                Assert.That(SalePosts[0].Price, Is.EqualTo(post.Price));
                Assert.That(SalePosts[0].Car.CategoryId, Is.EqualTo(post.Car.Category.Id));
            });
        }

        [Test]
        public async Task AddPostShouldAddAPost()
        {
            Guid sellerId = SeededSeller.Id;

            //AddViewModel post = new AddViewModel()
            //{
            //    Description = "",
            //    VinNumber = "",
            //    TechnicalSpecificationURL = "",
            //    EngineDisplacement = 1700,
            //    CategoryId = 5,
            //    EngineFuelType = "Diesel",
            //    ColorId = 5,
            //    EngineHorsePower = 116,
            //    Images = null,
            //    ThumbnailImage = new File(),

            //}
        }
    }
}
