namespace CarMarketplace.Services.Tests
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Data;
    using CarMarketplace.Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class UserServiceTests
    {
        private DbContextOptions<CarMarketplaceDbContext> dbOptions;
        private CarMarketplaceDbContext dbContext;

        private IUserService userService;

        public static ApplicationUser User;
        public static ApplicationUser SellerUser;
        public static Seller SeededSeller;
        public static Province Province;
        public static City City;
        public static SaleCar CarOne;
        public static SaleCar CarTwo;
        public static SalePost ActivePost;
        public static SalePost ArchivedPost;
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
        }

        [Test]
        public async Task AddToUserFavouritesShouldAddToFavourites()
        {
            Guid postId = ActivePost.Id;
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

            SalePostUser = new SalePostApplicationUser()
            {
                SalePost = ActivePost,
                SalePostId = ActivePost.Id,
                User = User,
                UserId = User.Id
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
            dbContext.SalePostApplicationUsers.Add(SalePostUser);
            dbContext.SaveChanges();
        }

    }
}
