namespace CarMarketplace.Services.Tests
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Data;
    using CarMarketplace.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Web.ViewModels.Common;

    public class UserServiceTests
    {
        private DbContextOptions<CarMarketplaceDbContext> dbOptions;
        private CarMarketplaceDbContext dbContext;

        private IUserService userService;

        public static ApplicationUser User;
        public static ApplicationUser SellerUser;
        public static ApplicationUser LenderUser;
        public static Seller SeededSeller;
        public static Lender SeededLender;
        public static Province Province;
        public static City City;
        public static SaleCar CarOne;
        public static SaleCar CarTwo;
        public static RentCar CarThird;
        public static Rented Rent;
        public static SalePost ActivePost;
        public static SalePost PostToLike;
        public static SalePost ArchivedPost;
        public static RentPost RentPostOne;
        public static SalePostApplicationUser SalePostUser;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarMarketplaceDbContext>()
                .UseInMemoryDatabase("CarMarketplaceInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new CarMarketplaceDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();

            this.userService = new UserService(this.dbContext);

            SeedDatabase(this.dbContext);

            AutoMapperConfig.RegisterMappings(typeof(CarManufacturerViewModel).Assembly);
        }

        [Test]
        public async Task AddToUserFavouritesShouldAddToFavourites()
        {
            Guid postId = ArchivedPost.Id;
            string userId = User.Id.ToString();

            await userService.AddToUserFavouritesAsync(postId, userId);

            Assert.IsTrue(await this.dbContext.SalePostApplicationUsers.AnyAsync(x => x.SalePostId == postId));
            Assert.IsTrue(await this.dbContext.SalePostApplicationUsers.AnyAsync(x => x.UserId == Guid.Parse(userId)));
        }

        [Test]
        public async Task GetUserFavouritesShouldReturnCorrectPosts()
        {
            var userId = User.Id.ToString();

            var posts = await this.userService.GetUserFavouritesAsync(userId);

            Assert.IsNotNull(posts);
            Assert.IsTrue(posts.Any(x => x.SalePost.Id == ActivePost.Id));
        }

        [Test]
        public async Task GetUserFavouritePostIdsShouldReturnCorrectCollection()
        {
            var userId = User.Id.ToString();

            var postIds = await this.userService.GetUserFavouritePostIdsAsync(userId);

            Assert.IsNotNull(postIds);
            Assert.That(postIds.Count, Is.EqualTo(1));
            Assert.IsTrue(postIds.Any(x => x.Equals(ActivePost.Id)));
        }

        [Test]
        public async Task RemoveUserFavouritePostShouldRemoveFromFavourites()
        {
            Guid postId = ActivePost.Id;
            var userId = User.Id.ToString();

            await this.userService.RemoveUserFavouritePostAsync(postId, userId);

            Assert.IsFalse(await this.dbContext.SalePostApplicationUsers.AnyAsync(x => x.SalePostId == postId && x.UserId == Guid.Parse(userId)));
        }

        [Test]
        public async Task UserHasRentedVehicleShouldReturnTrue()
        {
            var userId = User.Id.ToString();

            var result = await this.userService.UserHasRentedVehicleAsync(userId);

            Assert.IsTrue(result);
        }
        
        [Test]
        public async Task UserHasRentedVehicleShouldReturnFalse()
        {
            var userId = SellerUser.Id.ToString();

            var result = await this.userService.UserHasRentedVehicleAsync(userId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetUserRentedVehicleShouldReturnCorrectPosts()
        {
            var userId = User.Id.ToString();

            var model = await this.userService.GetUserRentedVehicleAsync(userId);

            Assert.IsNotNull(model);
            Assert.Multiple(() =>
            {
                Assert.That(model.Id, Is.EqualTo(Rent.RentPost.Id));
                Assert.That(model.Car.Id, Is.EqualTo(Rent.RentPost.Car.Id));
            });
        }

        [Test]
        public async Task ReturnRentedCarShouldRemoveRentedSuccessfully()
        {
            var userId = User.Id.ToString();
            var postId = RentPostOne.Id;

            await this.userService.ReturnRentedCarAsync(postId, userId);

            Assert.IsFalse(await this.dbContext.Rents.AnyAsync(x => x.PostId == postId && x.ClientId == Guid.Parse(userId)));
            Assert.IsFalse(this.dbContext.RentPosts.First(x => x.Id == postId).IsRented);
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

            LenderUser = new ApplicationUser()
            {
                UserName = "acheto@gmail.com",
                NormalizedUserName = "ACHETO@GMAIL.COM",
                Email = "acheto@gmail.com",
                NormalizedEmail = "ACHETO@GMAIL.COM",
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

            SeededLender = new Lender()
            {
                Id = Guid.Parse("e7868936-cd31-43e4-8aa7-8a74e6642edd"),
                PhoneNumber = "+359888888888",
                CityId = 1,
                Address = "TestAddress",
                CompanyName = "Company name",
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

            CarThird = new RentCar()
            {
                Id = Guid.Parse("4a8698c4-dc3e-4585-93b1-a8a10cecfbe2"),
                ManufacturerId = 3,
                ModelId = 20,
                CategoryId = 3,
                EngineId = 2,
                EuroStandart = 3,
                Seats = 4,
                BootCapacity = 50,
                Year = 2008,
                TransmissionType = "Automatic"
            };

            RentPostOne = new RentPost()
            {
                Id = Guid.Parse("d094d27a-1aa4-4bff-b59b-1878c472960d"),
                Car = CarThird,
                PricePerDay = 90,
                CreatedOn = DateTime.Now,
                ImagePublicId = "test",
                Lender = SeededLender,
                LenderId = SeededLender.Id,
                CarId = CarThird.Id
            };

            Rent = new Rented()
            {
                Client = User,
                ClientId = User.Id,
                PickUpDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(2),
                Email = User.UserName,
                FullName = "Test Name",
                RentPost = RentPostOne,
                PostId = RentPostOne.Id,
                PhoneNumber = "+35984673727"
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

            PostToLike = new SalePost()
            {
                Car = CarTwo,
                Price = 1000,
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

            SalePostUser = new SalePostApplicationUser()
            {
                SalePost = ActivePost,
                SalePostId = ActivePost.Id,
                User = User,
                UserId = User.Id
            };

            dbContext.Users.Add(User);
            dbContext.Users.Add(SellerUser);
            dbContext.Users.Add(LenderUser);
            dbContext.Sellers.Add(SeededSeller);
            dbContext.Lenders.Add(SeededLender);
            dbContext.Provinces.Add(Province);
            dbContext.Cities.Add(City);
            dbContext.SaleCars.Add(CarOne);
            dbContext.SaleCars.Add(CarTwo);
            dbContext.RentCars.Add(CarThird);
            dbContext.SalePosts.Add(ActivePost);
            dbContext.SalePosts.Add(ArchivedPost);
            dbContext.RentPosts.Add(RentPostOne);
            dbContext.Rents.Add(Rent);
            dbContext.SalePostApplicationUsers.Add(SalePostUser);
            dbContext.SaveChanges();
        }

    }
}
