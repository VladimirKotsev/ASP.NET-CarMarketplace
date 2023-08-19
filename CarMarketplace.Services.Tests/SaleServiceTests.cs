namespace CarMarketplace.Services.Tests
{
    using CarMarketplace.Data;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Web.ViewModels.Common;
    using Microsoft.EntityFrameworkCore;
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Catalog;

    public class SaleServiceTests
    {

        private DbContextOptions<CarMarketplaceDbContext> dbOptions;
        private CarMarketplaceDbContext dbContext;

        private ISaleService saleService;

        public static ApplicationUser User;
        public static ApplicationUser SellerUser;
        public static Seller SeededSeller;
        public static Province Province;
        public static City City;
        public static SaleCar CarOne;
        public static SaleCar CarTwo;
        public static SaleCar BMW;
        public static SaleCar Fiat;
        public static SaleCar Toyota;
        public static SalePost BMWPost;
        public static SalePost FiatPost;
        public static SalePost ToyotaPost;
        public static SalePost ActivePost;
        public static SalePost ArchivedPost;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarMarketplaceDbContext>()
                .UseInMemoryDatabase("CarMarketplaceInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new CarMarketplaceDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase();

            this.saleService = new SaleService(this.dbContext);

            AutoMapperConfig.RegisterMappings(typeof(CarManufacturerViewModel).Assembly);
        }

        //BMW = new SaleCar()
        //{
        //    ManufacturerId = 2,
        //        ModelId = 20,
        //        CategoryId = 3,
        //        ColorId = 1,
        //        EngineId = 2,
        //        EuroStandart = 5,
        //        Odometer = 123456,
        //        Year = 2009,
        //        TransmissionType = "Automatic"
        //    }

        //BMWPost = new SalePost()
        //{
        //    Car = BMW,
        //        CarId = BMW.Id,
        //        Price = 12000,
        //        CreatedOn = DateTime.Now,
        //        ThumbnailImagePublicId = "test",
        //        ImagePublicIds = "test",
        //        Seller = SeededSeller,
        //        SellerId = SeededSeller.Id,
        //    };
        [Test]
        public async Task GetFilteredSalePostsShouldFilterPostsCorrectly()
        {
            var model = new SearchViewModel()
            {
                Make = 2,
                ModelName = "4 Series",
                Category = 3,
                ProvinceId = 1,
                FromHorsepower = 79,
                ToHorsepower = 81,
                FromKilometers = 123455,
                ToKilometers = 123457,
                FromEuro = 5,
                FromYear = 2009,
                ToYear = 2009,
                City = null,
                FromPrice = 11990,
                ToPrice = 12000,
                TransmissionType = "Automatic",
                EngineFuelType = "Petrol"
            };

            var posts = await this.saleService.GetFilteredSalePostsAsync(model, 0);

            Assert.IsNotNull(posts);
            Assert.IsNotEmpty(posts.SalePosts);
            Assert.That(posts.SalePosts.Count, Is.EqualTo(1));
            Assert.That(posts.SalePosts.First().Id, Is.EqualTo(BMWPost.Id));
        }

        [Test]
        public async Task GetLatestSalePostsShouldReturnLates6Posts()
        {
            var model = await this.saleService.GetLatestSalePostsAsync();

            Assert.IsNotNull(model);
            Assert.That(model.Count, Is.EqualTo(6));
            Assert.That(model.First().Id, Is.EqualTo(this.dbContext
                .SalePosts
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedOn)
                .First().Id));
        }

        [Test]
        public async Task GetSalePostsByNationShouldReturnGermanPostsOnly()
        {
            var posts = await this.saleService.GetSalePostsByNationAsync("german");

            Assert.IsNotNull(posts);
            Assert.IsTrue(posts.Any(x => x.Id == BMWPost.Id));
        }
        
        [Test]
        public async Task GetSalePostsByNationShouldReturnItalianPostsOnly()
        {
            var posts = await this.saleService.GetSalePostsByNationAsync("italian");

            Assert.IsNotNull(posts);
            Assert.IsTrue(posts.Any(x => x.Id == FiatPost.Id));
        }
        
        [Test]
        public async Task GetSalePostsByNationShouldReturnJapanPostsOnly()
        {
            var posts = await this.saleService.GetSalePostsByNationAsync("japan");

            Assert.IsNotNull(posts);
            Assert.IsTrue(posts.Any(x => x.Id == ToyotaPost.Id));
        }

        [Test]
        public async Task GetSearchViewModelShouldReturnModelCorrectly()
        {
            var model = new SearchViewModel();

            model = await this.saleService.GetSearchViewModelAsync(model);

            Assert.IsNotNull(model);

            Assert.IsNotNull(model.Makes);
            Assert.IsNotNull(model.Categories);
            Assert.IsNotNull(model.Provinces);

            Assert.IsNotEmpty(model.Makes);
            Assert.IsNotEmpty(model.Categories);
            Assert.IsNotEmpty(model.Provinces);

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

            var make = new CarManufacturer()
            {
                Name = "test",
            };

            var model = new CarModel()
            {
                ModelName = "model",
                ManufacturerName = "test"
            };

            var engine = new Engine()
            {
                Displacement = 1500,
                FuelType = "Petrol",
                Horsepower = 150
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
                Manufacturer = make,
                Model = model,
                CategoryId = 3,
                ColorId = 1,
                Engine = engine,
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

            BMW = new SaleCar()
            {
                ManufacturerId = 2,
                ModelId = 20,
                CategoryId = 3,
                ColorId = 1,
                EngineId = 2,
                EuroStandart = 5,
                Odometer = 123456,
                Year = 2009,
                TransmissionType = "Automatic"
            };

            Fiat = new SaleCar()
            {
                ManufacturerId = 10,
                ModelId = 61,
                CategoryId = 3,
                ColorId = 1,
                EngineId = 2,
                EuroStandart = 3,
                Odometer = 12000,
                Year = 2000,
                TransmissionType = "Automatic"
            };
            
            Toyota = new SaleCar()
            {
                ManufacturerId = 12,
                ModelId = 73,
                CategoryId = 2,
                ColorId = 5,
                EngineId = 2,
                EuroStandart = 3,
                Odometer = 1200,
                Year = 1997,
                TransmissionType = "Manual"
            };

            BMWPost = new SalePost()
            {
                Car = BMW,
                CarId = BMW.Id,
                Price = 12000,
                CreatedOn = DateTime.Now,
                ThumbnailImagePublicId = "test",
                ImagePublicIds = "test",
                Seller = SeededSeller,
                SellerId = SeededSeller.Id,
            };
            
            FiatPost = new SalePost()
            {
                Car = Fiat,
                CarId = Fiat.Id,
                Price = 1000,
                CreatedOn = DateTime.Now,
                ThumbnailImagePublicId = "test",
                ImagePublicIds = "test",
                Seller = SeededSeller,
                SellerId = SeededSeller.Id,
            };
            
            ToyotaPost = new SalePost()
            {
                Car = Toyota,
                CarId = Toyota.Id,
                Price = 5000,
                CreatedOn = DateTime.Now,
                ThumbnailImagePublicId = "test",
                ImagePublicIds = "test",
                Seller = SeededSeller,
                SellerId = SeededSeller.Id,
            };

            ActivePost = new SalePost()
            {
                Id = Guid.Parse("d094d27a-1aa4-4bff-b59b-1878c472960d"),
                Car = CarOne,
                CarId = CarOne.Id,
                Price = 12000,
                CreatedOn = DateTime.Now,
                ThumbnailImagePublicId = "test",
                ImagePublicIds = "test",
                Seller = SeededSeller,
                SellerId = SeededSeller.Id,
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
            dbContext.Models.Add(model);
            dbContext.Manufacturers.Add(make);
            dbContext.Engines.Add(engine);
            dbContext.Users.Add(SellerUser);
            dbContext.Sellers.Add(SeededSeller);
            dbContext.Provinces.Add(Province);
            dbContext.Cities.Add(City);
            dbContext.SaleCars.Add(CarOne);
            dbContext.SaleCars.Add(CarTwo);
            dbContext.SaleCars.Add(BMW);
            dbContext.SaleCars.Add(Fiat);
            dbContext.SaleCars.Add(Toyota);
            dbContext.SalePosts.Add(ActivePost);
            dbContext.SalePosts.Add(BMWPost);
            dbContext.SalePosts.Add(FiatPost);
            dbContext.SalePosts.Add(ToyotaPost);
            dbContext.SalePosts.Add(ArchivedPost);
            dbContext.SaveChanges();
        }
    }
}
