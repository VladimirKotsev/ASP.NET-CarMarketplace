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

        public static ApplicationUser User;
        public static ApplicationUser SellerUser;
        public static Seller SeededSeller;
        public static Province Province;
        public static City City;
        public static SaleCar CarOne;
        public static SaleCar CarTwo;
        public static SalePost ActivePost;
        public static SalePost ArchivedPost;


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

            this.SellerService = new SellerService(this.dbContext);
            SeedDatabase();
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
            string nonExistingSellerPhoneNumber = "0894577899";

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

        [Test]
        public async Task GetSellerArchivePostsShouldReturnCorrectPosts()
        {
            Guid sellerId = Guid.Parse("e7868936-cd31-43e4-8aa7-8a74e6642edd");

            var archivedPosts = await this.SellerService.GetSellerArchivePostsAsync(sellerId);

            Assert.That(archivedPosts.Count, Is.EqualTo(1));
            Assert.IsTrue(archivedPosts.Any(x => x.Car.Id == Guid.Parse("4a8698c4-dc3e-4585-93b1-a8a10cecfbe2")));
        }

        [Test]
        public async Task ActiveSellerPostShouldActivatePost()
        {
            Guid postId = Guid.Parse("5c5ae02d-1ef4-483d-8b44-e46ef7cfe1af");

            await this.SellerService.ActiveSellerPostAsync(postId);

            Assert.IsFalse(ArchivedPost.IsDeleted);
        }

        private void SeedDatabase()
        {
            User = new ApplicationUser()
            {
                UserName = "vk1@gmail.com",
                NormalizedUserName = "VK1@GMAIL.COM",
                Email = "vk1@gmail.com",
                NormalizedEmail = "VK1@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = "5b1cb62b13d4386f2ad15af752f559d567f2ea3f32fc9d5d2d1c44e021f2d783",
                SecurityStamp = "f442941a-20ef-4665-8c05-088d3a9377c1",
                ConcurrencyStamp = "2bd5b738-c818-4136-8114-43fcb7279bdc",
                TwoFactorEnabled = false,
                PhoneNumber = null,
                PhoneNumberConfirmed = false
            };

            SellerUser = new ApplicationUser()
            {
                UserName = "vk@gmail.com",
                NormalizedUserName = "VK@GMAIL.COM",
                Email = "vk@gmail.com",
                NormalizedEmail = "VK@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                SecurityStamp = "be9a3d6a-a017-4980-b77e-f7d47278712f",
                ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                TwoFactorEnabled = false,
                PhoneNumber = null,
                PhoneNumberConfirmed = false
            };


            Province = new Province()
            {
                ProvinceName = "Kuystendil"
            };

            City = new City()
            {
                Province = Province,
                CityName = "Kuystendil"
            };
            SeededSeller = new Seller()
            {
                Id = Guid.Parse("e7868936-cd31-43e4-8aa7-8a74e6642edd"),
                PhoneNumber = "+359888888888",
                CityId = 1,
                FirstName = "Gosho",
                LastName = "Petrov",
                User = SellerUser,
                City = City,
            };
            dbContext.Cities.Add(City);


            City = new City()
            {
                Province = Province,
                CityName = "Bobovdol"
            };

            CarOne = new SaleCar()
            {
                ManufacturerId = 1,
                ModelId = 5,
                CategoryId = 3,
                ColorId = 1,
                EngineId = 2,
                EuroStandart = 3,
                Odometer = 1200,
                Year = 2007,
                TransmissionType = "Manual"
            };

            CarTwo = new SaleCar()
            {
                Id = Guid.Parse("4a8698c4-dc3e-4585-93b1-a8a10cecfbe2"),
                ManufacturerId = 3,
                ModelId = 20,
                CategoryId = 3,
                ColorId = 1,
                EngineId = 2,
                EuroStandart = 3,
                Odometer = 1200,
                Year = 2008,
                TransmissionType = "Automatic"
            };
     
            ActivePost = new SalePost()
            {
                Id = Guid.Parse("d094d27a-1aa4-4bff-b59b-1878c472960d"),
                Car = CarOne,
                Price = 12000,
                CreatedOn = DateTime.Now,
                ThumbnailImagePublicId = "test",
                ImagePublicIds = "test",
                Seller = SeededSeller,
                SellerId = SeededSeller.Id
            };

            ArchivedPost = new SalePost()
            {
                Id = Guid.Parse("5c5ae02d-1ef4-483d-8b44-e46ef7cfe1af"),
                Car = CarTwo,
                Price = 15000,
                CreatedOn = DateTime.Now,
                ThumbnailImagePublicId = "test",
                ImagePublicIds = "test",
                Seller = SeededSeller,
                SellerId = SeededSeller.Id,
                IsDeleted = true
            };

            dbContext.Users.Add(User);
            dbContext.Users.Add(SellerUser);
            dbContext.Sellers.Add(SeededSeller);
            dbContext.Provinces.Add(Province);
            dbContext.Cities.Add(City);
            dbContext.SaleCars.Add(CarOne);
            dbContext.SaleCars.Add(CarTwo);
            dbContext.SalePosts.Add(ActivePost);
            dbContext.SalePosts.Add(ArchivedPost);
            dbContext.SaveChanges();
        }
    }
}