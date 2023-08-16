namespace CarMarketplace.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;

    using static DatabaseSeeder;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.Seller;

    public class SellerServiceTests
    {
        private DbContextOptions<CarMarketplaceDbContext> dbOptions;
        private CarMarketplaceDbContext dbContext;

        private ISellerService SellerService;

        public SellerServiceTests()
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

            this.SellerService = new SellerService(this.dbContext);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task SellerExistbyUserIdAsyncShouldReturnTrueWhenExisting()
        {
            string existingSellerId = SellerUser.Id.ToString();

            bool result = await this.SellerService.SellerExistbyUserIdAsync(existingSellerId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task SellerExistbyUserIdAsyncShouldReturnFalseWhenNotExisting()
        {
            string nonExistingSellerId = User.Id.ToString();

            bool result = await this.SellerService.SellerExistbyUserIdAsync(nonExistingSellerId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task SellerExistbyPhoneNumberShouldReturnTrueWhenExisting()
        {
            string existingSellerPhoneNumber = SeededSeller.PhoneNumber;

            bool result = await this.SellerService.SellerExistbyPhoneNumberAsync(existingSellerPhoneNumber);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task SellerExistbyPhoneNumberShouldReturnFalseWhenExisting()
        {
            string nonExistingSellerPhoneNumber = "089457789";

            bool result = await this.SellerService.SellerExistbyPhoneNumberAsync(nonExistingSellerPhoneNumber);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetSellerIdByUserIdShouldReturnCorrectSellerId()
        {
            string userId = SeededSeller.UserId.ToString();
            string sellerId = SeededSeller.Id.ToString();

            Guid result = await this.SellerService.GetSellerIdByUserIdAsync(userId);

            Assert.That(sellerId, Is.EqualTo(result.ToString()));
        }

        [Test]
        public async Task CityExistByNameAsyncShouldReturnTrue()
        {
            string cityName = "Kuystendil";

            Assert.IsTrue(await this.SellerService.CityExistByNameAsync(cityName));
        }

        [Test]
        public async Task CityExistByNameAsyncShouldReturnFalse()
        {
            string cityName = "This is a test city name";

            Assert.IsFalse(await this.SellerService.CityExistByNameAsync(cityName));
        }

        [Test]
        public async Task RegisterUserAsSellerShouldRegisterUserCorrectly()
        {
            string userId = SellerUser.Id.ToString();

            var sellerInfo = new SellerPersonalInfoViewModel()
            {
                PhoneNumber = "0894567899",
                City = "Sofia",
                FirstName = "Test",
                LastName = "Test2",
            };

            await SellerService.RegisterUserAsSellerAsync(userId, sellerInfo);
            Assert.IsTrue(await SellerService.SellerExistbyUserIdAsync(userId));
            Assert.IsTrue(await SellerService.SellerExistbyPhoneNumberAsync("0894567899"));
        }

        [Test]
        public async Task GetSellerPostsShouldReturnCorrectPosts()
        {
            Guid sellerId = Guid.Parse("e7868936-cd31-43e4-8aa7-8a74e6642edd");

            ICollection<SalePostViewModel> sellerPosts = await this.SellerService.GetSellerPostsAsync(sellerId);

            SalePostViewModel firstPost = sellerPosts.First();
            SalePostViewModel secondPost = sellerPosts.Skip(1).First();


            Assert.That(sellerPosts.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(firstPost.Id, Is.EqualTo(Guid.Parse("d094d27a-1aa4-4bff-b59b-1878c472960d")));
                Assert.That(firstPost.Price, Is.EqualTo(12000));
                Assert.That(firstPost.Car.Year, Is.EqualTo(2007));
                Assert.That(firstPost.Car.Model.Id, Is.EqualTo(5));
            });
            Assert.Multiple(() =>
            {
                Assert.That(secondPost.Id, Is.EqualTo(Guid.Parse("5c5ae02d-1ef4-483d-8b44-e46ef7cfe1af")));
                Assert.That(secondPost.Price, Is.EqualTo(15000));
                Assert.That(secondPost.Car.Year, Is.EqualTo(2008));
                Assert.That(secondPost.Car.Model.Id, Is.EqualTo(20));
            });
        }
    }
}