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
    using AutoMapper;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Data.Models;
    using CloudinaryDotNet.Actions;
    using Moq;
    using System.Text;
    using Microsoft.AspNetCore.Http.Internal;
    using CarMarketplace.Web.ViewModels.Common;

    public class SalePostServiceTests
    {
        private readonly ICloudinaryService MediaService;

        private DbContextOptions<CarMarketplaceDbContext> dbOptions;
        private CarMarketplaceDbContext dbContext;

        private ISalePostService salePostService;

        public static ApplicationUser User;
        public static ApplicationUser SellerUser;
        public static Seller SeededSeller;
        public static Province Province;
        public static City City;
        public static SaleCar CarOne;
        public static SaleCar CarTwo;
        public static SalePost ActivePost;
        public static SalePost ArchivedPost;


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
            SeedDatabase();

            var cloudinaryServiceMock = new Mock<ICloudinaryService>();
            cloudinaryServiceMock.Setup(service => service.UploadAsync(It.IsAny<ImageUploadParams>()))
                .ReturnsAsync(new ImageUploadResult() { Url = new Uri("https://res.cloudinary.com/carmarketplace/image/upload/v1692027136/f075eac8-93d6-4a5d-906e-0c44b0ecabee.jpg") });

            var mediaService = new MediaService(cloudinaryServiceMock.Object);

            this.salePostService = new SalePostService(this.dbContext, mediaService);

            AutoMapperConfig.RegisterMappings(typeof(CarManufacturerViewModel).Assembly);
        }

        [Test]
        public async Task GetSalePostByIdShouldReturnCorrectPost()
        {
            var postId = ActivePost.Id;

            var post = await salePostService.GetSalePostByIdAsync(postId);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(post);
                Assert.That(postId, Is.EqualTo(post.Id));
                Assert.That(ActivePost.Price, Is.EqualTo(post.Price));
                Assert.That(ActivePost.Car.CategoryId, Is.EqualTo(post.Car.Category.Id));
            });
        }

        [Test]
        public async Task DeletePostShouldDeletePost()
        {
            var postId = ArchivedPost.Id;
            var carId = ArchivedPost.Car.Id;

            await this.salePostService.DeletePostAsync(postId, carId);

            Assert.IsFalse(await this.dbContext.SaleCars.AnyAsync(x => x.Id == carId));
            Assert.IsFalse(await this.dbContext.SalePosts.AnyAsync(x => x.Id == postId));
        }

        [Test]
        public async Task GetAddPostViewModelShouldReturnCorrectModel()
        {
            var model = new AddViewModel();

            model = await this.salePostService.GetAddPostViewModelAsync(model);

            Assert.NotNull(model);
            Assert.NotNull(model.Makes);
            Assert.NotNull(model.Colors);
            Assert.NotNull(model.Categories);
        }

        [Test]
        public async Task AddPostShouldAddAPostWithoutPhotos()
        {
            Guid sellerId = SeededSeller.Id;

            var formFile = new FormFile(
                baseStream: new MemoryStream(Encoding.UTF8.GetBytes("Mock file content")),
                baseStreamOffset: 0,
                length: "Mock file content".Length,
                name: "Photo",
                fileName: "test.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            AddViewModel model = new AddViewModel()
            {
                Description = "This is a one of a kind car",
                VinNumber = "",
                TechnicalSpecificationURL = "",
                EngineDisplacement = 1700,
                CategoryId = 5,
                EngineFuelType = "Diesel",
                ColorId = 5,
                EngineHorsePower = 116,
                ThumbnailImage = formFile,
                Year = 2000,
                Odometer = 200000,
                TransmissionType = "Manual",
                EuroStandart = 3, 
                Price = 12000,
                Model = "A4",
                MakeId = 1
            };

            var count = this.dbContext.SalePosts.Count();

            await this.salePostService.AddPostAsync(model, sellerId);

            Assert.That(this.dbContext.SalePosts.Count(), Is.EqualTo(count + 1));
            Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Car.Description == model.Description));
        }
        
        [Test]
        public async Task AddPostShouldAddAPostWithoutEngine()
        {
            Guid sellerId = SeededSeller.Id;

            var formFile = new FormFile(
                baseStream: new MemoryStream(Encoding.UTF8.GetBytes("Mock file content")),
                baseStreamOffset: 0,
                length: "Mock file content".Length,
                name: "Photo",
                fileName: "test.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            AddViewModel model = new AddViewModel()
            {
                Description = "This is a one of a kind car",
                VinNumber = "",
                TechnicalSpecificationURL = "",
                EngineDisplacement = 2000,
                CategoryId = 5,
                EngineFuelType = "Petrol",
                ColorId = 5,
                EngineHorsePower = 260,
                ThumbnailImage = formFile,
                Year = 2000,
                Odometer = 200000,
                TransmissionType = "Manual",
                EuroStandart = 3, 
                Price = 12000,
                Model = "A4",
                MakeId = 1
            };

            var count = this.dbContext.SalePosts.Count();

            await this.salePostService.AddPostAsync(model, sellerId);

            Assert.That(this.dbContext.SalePosts.Count(), Is.EqualTo(count + 1));
            Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Car.Description == model.Description));
            Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Car.Engine.Horsepower == model.EngineHorsePower));
            Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Car.Engine.Displacement == model.EngineDisplacement));
        }
        
        [Test]
        public async Task AddPostShouldAddAPostWithoutModel()
        {
            Guid sellerId = SeededSeller.Id;

            var formFile = new FormFile(
                baseStream: new MemoryStream(Encoding.UTF8.GetBytes("Mock file content")),
                baseStreamOffset: 0,
                length: "Mock file content".Length,
                name: "Photo",
                fileName: "test.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            AddViewModel model = new AddViewModel()
            {
                Description = "This is a one of a kind car",
                VinNumber = "",
                TechnicalSpecificationURL = "",
                EngineDisplacement = 2000,
                CategoryId = 5,
                EngineFuelType = "Petrol",
                ColorId = 5,
                EngineHorsePower = 260,
                ThumbnailImage = formFile,
                Year = 2000,
                Odometer = 200000,
                TransmissionType = "Manual",
                EuroStandart = 3, 
                Price = 12000,
                Model = "test",
                MakeId = 1
            };

            var count = this.dbContext.SalePosts.Count();

            await this.salePostService.AddPostAsync(model, sellerId);

            Assert.That(this.dbContext.SalePosts.Count(), Is.EqualTo(count + 1));
            Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Car.Description == model.Description));
            Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Car.Model.ModelName == model.Model));
        }
        [Test]
        public async Task AddPostShouldAddAPostWithPhotos()
        {
            Guid sellerId = SeededSeller.Id;

            var formFile = new FormFile(
                baseStream: new MemoryStream(Encoding.UTF8.GetBytes("Mock file content")),
                baseStreamOffset: 0,
                length: "Mock file content".Length,
                name: "Photo",
                fileName: "test.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            ICollection<IFormFile> images = new HashSet<IFormFile>() { formFile };

            AddViewModel model = new AddViewModel()
            {
                Description = "This is a one of a kind car",
                VinNumber = "",
                TechnicalSpecificationURL = "",
                EngineDisplacement = 2000,
                CategoryId = 5,
                EngineFuelType = "Petrol",
                ColorId = 5,
                EngineHorsePower = 260,
                ThumbnailImage = formFile,
                Year = 2000,
                Images = images,
                Odometer = 200000,
                TransmissionType = "Manual",
                EuroStandart = 3, 
                Price = 12000,
                Model = "test",
                MakeId = 1
            };

            var count = this.dbContext.SalePosts.Count();

            await this.salePostService.AddPostAsync(model, sellerId);

            Assert.That(this.dbContext.SalePosts.Count(), Is.EqualTo(count + 1));
            Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Car.Description == model.Description));
        }

        [Test]
        public async Task GetEditViewModelByPostIdShouldReturnCorrectViewModel()
        {
            var postId = ActivePost.Id;
            var model = new EditViewModel();

            var result = await this.salePostService.GetEditViewModelByPostIdAsync(model, postId);

            Assert.NotNull(result);
            Assert.NotNull(result.Makes);
            Assert.NotNull(result.Colors);
            Assert.NotNull(result.Categories);
            Assert.That(ActivePost.Car.Manufacturer.Id, Is.EqualTo(result.MakeId));
        }

        [Test]
        public async Task EditPostByIdShouldEditPostSuccessfully()
        {
            var actualOdometer = 300000;
            var actualEuroStandart = 2;

            EditViewModel model = new EditViewModel();

            model.PostId = ActivePost.Id;
            model.MakeId = ActivePost.Car.ManufacturerId; ;
            model.Model = ActivePost.Car.Model.ModelName;
            model.ColorId = ActivePost.Car.ColorId;
            model.Year = ActivePost.Car.Year;
            model.EngineDisplacement = (int)ActivePost.Car.Engine.Displacement!;
            model.EngineFuelType = ActivePost.Car.Engine.FuelType;
            model.EngineHorsePower = ActivePost.Car.Engine.Horsepower;
            model.Odometer = actualOdometer;
            model.TransmissionType = ActivePost.Car.TransmissionType;
            model.EuroStandart = actualEuroStandart;
            model.CategoryId = ActivePost.Car.CategoryId;
            model.Price = ActivePost.Price;
            model.CategoryId = ActivePost.Car.CategoryId;

            var formFile = new FormFile(
                baseStream: new MemoryStream(Encoding.UTF8.GetBytes("Mock file content")),
                baseStreamOffset: 0,
                length: "Mock file content".Length,
                name: "Photo",
                fileName: "test.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            model.ThumbnailImage = formFile;

            await this.salePostService.EditPostByIdAsync(model);

            Assert.Multiple(async () =>
            {
                Assert.That(actualOdometer, Is.EqualTo(await this.dbContext
                    .SalePosts
                    .Where(x => x.Id == ActivePost.Id)
                    .Select(x => x.Car.Odometer)
                    .FirstAsync()));
                Assert.That(actualEuroStandart, Is.EqualTo(await this.dbContext
                    .SalePosts
                    .Where(x => x.Id == ActivePost.Id)
                    .Select(x => x.Car.EuroStandart)
                    .FirstAsync()));
            });
        }
        
        [Test]
        public async Task EditPostByIdShouldEditPostWithoutEngine()
        {
            var actualOdometer = 300000;
            var actualEuroStandart = 2;

            EditViewModel model = new EditViewModel();

            model.PostId = ActivePost.Id;
            model.MakeId = ActivePost.Car.ManufacturerId; ;
            model.Model = ActivePost.Car.Model.ModelName;
            model.ColorId = ActivePost.Car.ColorId;
            model.Year = ActivePost.Car.Year;
            model.EngineDisplacement = 2100;
            model.EngineFuelType = "Petrol";
            model.EngineHorsePower = 250;
            model.Odometer = actualOdometer;
            model.TransmissionType = ActivePost.Car.TransmissionType;
            model.EuroStandart = actualEuroStandart;
            model.CategoryId = ActivePost.Car.CategoryId;
            model.Price = ActivePost.Price;
            model.CategoryId = ActivePost.Car.CategoryId;

            var formFile = new FormFile(
                baseStream: new MemoryStream(Encoding.UTF8.GetBytes("Mock file content")),
                baseStreamOffset: 0,
                length: "Mock file content".Length,
                name: "Photo",
                fileName: "test.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            model.ThumbnailImage = formFile;

            await this.salePostService.EditPostByIdAsync(model);

            Assert.Multiple(async () =>
            {
                Assert.That(actualOdometer, Is.EqualTo(await this.dbContext
                    .SalePosts
                    .Where(x => x.Id == ActivePost.Id)
                    .Select(x => x.Car.Odometer)
                    .FirstAsync()));
                Assert.That(actualEuroStandart, Is.EqualTo(await this.dbContext
                    .SalePosts
                    .Where(x => x.Id == ActivePost.Id)
                    .Select(x => x.Car.EuroStandart)
                    .FirstAsync()));
                Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Car.Engine.Horsepower == 250));
                Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Car.Engine.Displacement == 2100));
            });
        }

        [Test]
        public async Task EditPostByIdShouldEditPostWithoutModel()
        {
            var actualOdometer = 300000;
            var actualEuroStandart = 2;

            EditViewModel model = new EditViewModel();

            model.PostId = ActivePost.Id;
            model.MakeId = ActivePost.Car.ManufacturerId;
            model.Model = "test";
            model.ColorId = ActivePost.Car.ColorId;
            model.Year = ActivePost.Car.Year;
            model.EngineDisplacement = (int)ActivePost.Car.Engine.Displacement;
            model.EngineFuelType = ActivePost.Car.Engine.FuelType;
            model.EngineHorsePower = ActivePost.Car.Engine.Horsepower;
            model.Odometer = actualOdometer;
            model.TransmissionType = ActivePost.Car.TransmissionType;
            model.EuroStandart = actualEuroStandart;
            model.CategoryId = ActivePost.Car.CategoryId;
            model.Price = ActivePost.Price;
            model.CategoryId = ActivePost.Car.CategoryId;

            var formFile = new FormFile(
                baseStream: new MemoryStream(Encoding.UTF8.GetBytes("Mock file content")),
                baseStreamOffset: 0,
                length: "Mock file content".Length,
                name: "Photo",
                fileName: "test.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            model.ThumbnailImage = formFile;

            await this.salePostService.EditPostByIdAsync(model);

            Assert.Multiple(async () =>
            {
                Assert.That(actualOdometer, Is.EqualTo(await this.dbContext
                    .SalePosts
                    .Where(x => x.Id == ActivePost.Id)
                    .Select(x => x.Car.Odometer)
                    .FirstAsync()));
                Assert.That(actualEuroStandart, Is.EqualTo(await this.dbContext
                    .SalePosts
                    .Where(x => x.Id == ActivePost.Id)
                    .Select(x => x.Car.EuroStandart)
                    .FirstAsync()));
                Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Car.Model.ModelName == "test"));
            });
        }

        [Test]
        public async Task EditPostByIdShouldEditPostWithPhotos()
        {
            var actualOdometer = 300000;
            var actualEuroStandart = 2;

            EditViewModel model = new EditViewModel();

            model.PostId = ActivePost.Id;
            model.MakeId = ActivePost.Car.ManufacturerId;
            model.Model = ActivePost.Car.Model.ModelName;
            model.ColorId = ActivePost.Car.ColorId;
            model.Year = ActivePost.Car.Year;
            model.EngineDisplacement = (int)ActivePost.Car.Engine.Displacement;
            model.EngineFuelType = ActivePost.Car.Engine.FuelType;
            model.EngineHorsePower = ActivePost.Car.Engine.Horsepower;
            model.Odometer = actualOdometer;
            model.TransmissionType = ActivePost.Car.TransmissionType;
            model.EuroStandart = actualEuroStandart;
            model.CategoryId = ActivePost.Car.CategoryId;
            model.Price = ActivePost.Price;
            model.CategoryId = ActivePost.Car.CategoryId;

            var formFile = new FormFile(
                baseStream: new MemoryStream(Encoding.UTF8.GetBytes("Mock file content")),
                baseStreamOffset: 0,
                length: "Mock file content".Length,
                name: "Photo",
                fileName: "test.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            ICollection<IFormFile> images = new HashSet<IFormFile>() { formFile };

            model.ThumbnailImage = formFile;
            model.Images = images;

            await this.salePostService.EditPostByIdAsync(model);

            Assert.Multiple(async () =>
            {
                Assert.That(actualOdometer, Is.EqualTo(await this.dbContext
                    .SalePosts
                    .Where(x => x.Id == ActivePost.Id)
                    .Select(x => x.Car.Odometer)
                    .FirstAsync()));
                Assert.That(actualEuroStandart, Is.EqualTo(await this.dbContext
                    .SalePosts
                    .Where(x => x.Id == ActivePost.Id)
                    .Select(x => x.Car.EuroStandart)
                    .FirstAsync()));
                Assert.IsFalse(String.IsNullOrEmpty(this.dbContext.SalePosts.First(x => x.Id == ActivePost.Id).ImagePublicIds));
            });
        }

        [Test]
        public async Task ArchivePostByIdShouldArchivePost()
        {
            Guid postId = ActivePost.Id;

            await this.salePostService.ArchivePostByIdAsync(postId);

            Assert.IsTrue(await this.dbContext.SalePosts.AnyAsync(x => x.Id == postId && x.IsDeleted == true));
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
            dbContext.SalePosts.Add(ActivePost);
            dbContext.SalePosts.Add(ArchivedPost);
            dbContext.SaveChanges();
        }
    }
}
