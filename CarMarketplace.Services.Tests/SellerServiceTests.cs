namespace CarMarketplace.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;

    using static DatabaseSeeder;
    using CarMarketplace.Services.Contracts;

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
            string existingSellerPhoneNumber = Seller.PhoneNumber;

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
            string userId = Seller.UserId.ToString();
            string sellerId = Seller.Id.ToString();

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

    }
}