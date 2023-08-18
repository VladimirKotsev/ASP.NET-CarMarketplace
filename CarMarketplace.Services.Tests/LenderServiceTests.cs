namespace CarMarketplace.Services.Tests
{
    using CarMarketplace.Data;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Lender;
    using Microsoft.EntityFrameworkCore;

    public class LenderServiceTests
    {
        private DbContextOptions<CarMarketplaceDbContext> dbOptions;
        private CarMarketplaceDbContext dbContext;

        private ILenderService lenderService;

        public static ApplicationUser User;
        public static ApplicationUser LenderUser;
        public static Lender SeededLender;
        public static Province Province;
        public static City City;
        public static RentCar CarOne;
        public static RentCar CarTwo;
        public static RentPost FirstPost;
        public static RentPost SecondPost;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarMarketplaceDbContext>()
                .UseInMemoryDatabase("CarMarketplaceInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new CarMarketplaceDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();

            this.lenderService = new LenderService(this.dbContext);
            SeedDatabase(this.dbContext);
        }

        [Test]
        public async Task GetLenderIdByUserIdShouldReturnCorrectLenderId()
        {
            var lenderId = await lenderService.GetLenderIdByUserIdAsync(LenderUser.Id.ToString());

            Assert.That(SeededLender.Id, Is.EqualTo(lenderId));
        }

        [Test]
        public async Task GetLenderPostsShouldReturnCorrectPosts()
        {
            Guid lenderId = SeededLender.Id;

            var postCollection = await lenderService.GetLenderPostsAsync(lenderId);

            Assert.That(2, Is.EqualTo(postCollection.Count));
        }

        [Test]
        public async Task LenderExistbyPhoneNumberShouldReturnTrueWhenExisting()
        {
            string lenderPhoneNumber = SeededLender.PhoneNumber;

            bool result = await this.lenderService.LenderExistbyPhoneNumberAsync(lenderPhoneNumber);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task LenderExistbyPhoneNumberShouldReturnFalseWhenNotExisting()
        {
            string lenderPhoneNumber = "0894566787";

            bool result = await this.lenderService.LenderExistbyPhoneNumberAsync(lenderPhoneNumber);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task LenderExistbyUserIdShouldReturnTrueWhenExising()
        {
            string userId = LenderUser.Id.ToString();

            bool result = await this.lenderService.LenderExistbyUserIdAsync(userId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task LenderExistbyUserIdShouldReturnFalseWhenNotExising()
        {
            string userId = User.Id.ToString();

            bool result = await this.lenderService.LenderExistbyUserIdAsync(userId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task RegisterUserAsLenderShouldRegisterUser()
        {
            string userId = User.Id.ToString();

            LenderPersonalInfoViewModel model = new LenderPersonalInfoViewModel()
            {
                PhoneNumber = "0894543212",
                CompanyName = "testCompany",
                City = "Sofia",
                Address = "testAddress"
            };
           
            await this.lenderService.RegisterUserAsLenderAsync(userId, model);

            Assert.IsTrue(await this.dbContext.Lenders.AnyAsync(l => l.PhoneNumber == model.PhoneNumber));
            Assert.IsTrue(await this.dbContext.Lenders.AnyAsync(l => l.CompanyName == model.CompanyName));
            Assert.IsTrue(await this.dbContext.Lenders.AnyAsync(l => l.City.CityName == model.City));
            Assert.IsTrue(await this.dbContext.Lenders.AnyAsync(l => l.Address == model.Address));
        }

        [Test]
        public async Task RegisterUserAsLenderShouldThrowException()
        {
            string userId = User.Id.ToString();

            LenderPersonalInfoViewModel model = new LenderPersonalInfoViewModel()
            {
                PhoneNumber = "0894543212",
                CompanyName = "testCompany",
                City = "testCity",
                Address = "testAddress"
            };
   
            Assert.ThrowsAsync<ArgumentException>(() => this.lenderService.RegisterUserAsLenderAsync(userId, model));      
        }

        public static void SeedDatabase(CarMarketplaceDbContext dbContext)
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

            LenderUser = new ApplicationUser()
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
            SeededLender = new Lender()
            {
                Id = Guid.Parse("e7868936-cd31-43e4-8aa7-8a74e6642edd"),
                PhoneNumber = "+359888888888",
                CityId = 1,
                Address = "test",
                CompanyName = "Rent now eood",
                User = LenderUser,
                City = City,
            };

            dbContext.Cities.Add(City);


            City = new City()
            {
                Province = Province,
                CityName = "Bobovdol"
            };

            City = new City()
            {
                Province = Province,
                CityName = "Bobovdol"
            };

            CarOne = new RentCar()
            {
                ManufacturerId = 1,
                ModelId = 5,
                CategoryId = 3,
                EngineId = 2,
                Seats = 4,
                BootCapacity = 60,
                EuroStandart = 3,
                Year = 2007,
                TransmissionType = "Manual"
            };

            CarTwo = new RentCar()
            {
                Id = Guid.Parse("4a8698c4-dc3e-4585-93b1-a8a10cecfbe2"),
                ManufacturerId = 3,
                ModelId = 20,
                CategoryId = 3,
                Seats = 5,
                BootCapacity = 30,
                EngineId = 2,
                EuroStandart = 3,
                Year = 2008,
                TransmissionType = "Automatic"
            };

            FirstPost = new RentPost()
            {
                Id = Guid.Parse("d094d27a-1aa4-4bff-b59b-1878c472960d"),
                Car = CarOne,
                PricePerDay = 72,
                CreatedOn = DateTime.Now,
                ImagePublicId = "test",
                Lender = SeededLender,
                LenderId = SeededLender.Id
            };

            SecondPost = new RentPost()
            {
                Id = Guid.Parse("5c5ae02d-1ef4-483d-8b44-e46ef7cfe1af"),
                Car = CarTwo,
                PricePerDay = 80,
                CreatedOn = DateTime.Now,
                ImagePublicId = "test",
                Lender = SeededLender,
                LenderId = SeededLender.Id,
            };

            dbContext.Users.Add(User);
            dbContext.Users.Add(LenderUser);
            dbContext.Lenders.Add(SeededLender);
            dbContext.Provinces.Add(Province);
            dbContext.Cities.Add(City);
            dbContext.RentCars.Add(CarOne);
            dbContext.RentCars.Add(CarTwo);
            dbContext.RentPosts.Add(FirstPost);
            dbContext.RentPosts.Add(SecondPost);
            dbContext.SaveChanges();
        }

    }
}