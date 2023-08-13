namespace CarMarketplace.Services.Tests
{
    using CarMarketplace.Data;
    using CarMarketplace.Data.Models;

    public static class DatabaseSeeder
    {
        public static ApplicationUser User;
        public static ApplicationUser SellerUser;
        public static Seller Seller;
        public static Province Province;
        public static City City;
        public static SaleCar Car;
        public static SalePost SalePost;

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

            Seller = new Seller()
            {
                PhoneNumber = "+359888888888",
                CityId = 1,
                FirstName = "Gosho",
                LastName = "Petrov",
                User = SellerUser
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
            dbContext.Cities.Add(City);
            

            City = new City()
            {
                Province = Province,
                CityName = "Bobovdol"
            };

            Car = new SaleCar()
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

            SalePost = new SalePost()
            {
                Id = Guid.Parse("d094d27a-1aa4-4bff-b59b-1878c472960d"),
                Car = Car,
                Price = 12000,
                CreatedOn = DateTime.Now,
                ThumbnailImagePublicId = "",
                ImagePublicIds = "",
                Seller = Seller
            };

            dbContext.Users.Add(User);
            dbContext.Users.Add(SellerUser);
            dbContext.Sellers.Add(Seller);
            dbContext.Provinces.Add(Province);
            dbContext.Cities.Add(City);
            dbContext.Cars.Add(Car);
            dbContext.SalePosts.Add(SalePost);
            dbContext.SaveChanges();
        }
    }
}
