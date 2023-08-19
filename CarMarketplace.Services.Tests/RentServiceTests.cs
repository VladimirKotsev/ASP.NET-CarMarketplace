namespace CarMarketplace.Services.Tests
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Data;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Web.ViewModels.Common;
    using Microsoft.EntityFrameworkCore;
    using CarMarketplace.Web.ViewModels.Rent;

    public class RentServiceTests
    {
        private DbContextOptions<CarMarketplaceDbContext> dbOptions;
        private CarMarketplaceDbContext dbContext;

        private IRentService rentService;

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

            this.rentService = new RentService(this.dbContext);

            SeedDatabase(this.dbContext);

            AutoMapperConfig.RegisterMappings(typeof(CarManufacturerViewModel).Assembly);
        }

        [Test]
        public async Task GetRentingPostViewModelShouldReturnCorrectModel()
        {
            var postId = FirstPost.Id;
            var userEmail = User.UserName;

            var model = await this.rentService.GetRentingPostViewModelAsync(postId, userEmail);

            Assert.IsNotNull(model);
            Assert.That(model.Post.Id, Is.EqualTo(postId));
            Assert.That(model.Email, Is.EqualTo(userEmail));
        }

        [Test]
        public async Task RentVehicleShouldRentVehicleForUserSuccessfully()
        {
            var userId = User.Id.ToString();

            var model = new RentingViewModel()
            {
                PostId = SecondPost.Id,
                Email = User.Email,
                FullName = "test name",
                PhoneNumber = "+359745367345",
                PickUpDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(1)
            };

            await this.rentService.RentVehicleAsync(userId, model);

            Assert.IsTrue(await this.dbContext.Rents.AnyAsync(x => x.ClientId == Guid.Parse(userId)));
            Assert.IsTrue(await this.dbContext.Rents.AnyAsync(x => x.Email == User.Email));
            Assert.IsTrue(await this.dbContext.Rents.AnyAsync(x => x.PhoneNumber == model.PhoneNumber));
            Assert.IsTrue(await this.dbContext.Rents.AnyAsync(x => x.FullName == model.FullName));
            Assert.IsTrue(this.dbContext.RentPosts.First(x => x.Id == SecondPost.Id).IsRented);
        }

        [Test]
        public async Task GetRentPostViewModelShouldReturnCorrectCollection()
        {
            var model = await this.rentService.GetRentPostViewModelAsync(0);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.RentPosts);
            Assert.IsNotEmpty(model.RentPosts);
            Assert.IsTrue(await this.dbContext.RentPosts.AnyAsync(x => x.Id == FirstPost.Id));
            Assert.IsTrue(await this.dbContext.RentPosts.AnyAsync(x => x.Id == SecondPost.Id));
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
