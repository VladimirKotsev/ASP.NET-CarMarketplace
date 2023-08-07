namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarMarketplace.Data.Models;

    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(x => x.Seller)
                .WithMany(x => x.CarOnSale)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(GenerateCars());
        }

        //This method seeds some example cars in the database
        private Car[] GenerateCars()
        {
            ICollection<Car> cars = new HashSet<Car>();

            cars.Add(new Car()
            {
                Id = Guid.Parse("864237e2-7f7a-469f-b019-697c848fc3aa"),
                ManufacturerId = 1,
                ModelId = 5,
                ColorId = 2,
                ProvinceId = 9,
                Year = 2009,
                EngineId = 3,
                Odometer = 209000,
                TransmissionType = "Manual",
                EuroStandart = 4,
                CategoryId = 2,
                SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                TechnicalSpecificationURL = "https://www.auto-data.net/en/audi-a3-sportback-8pa-facelift-2008-1.9-tdi-105hp-dpf-4215"
            });

            cars.Add(new Car()
            {
                Id = Guid.Parse("913c5349-94de-4dc2-9e7d-346b57648227"),
                ManufacturerId = 10,
                ModelId = 145,
                ColorId = 5,
                ProvinceId = 7,
                Year = 2000,
                EngineId = 2,
                Odometer = 219000,
                TransmissionType = "Manual",
                EuroStandart = 3,
                CategoryId = 2,
                SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                TechnicalSpecificationURL = "https://www.auto-data.net/en/fiat-punto-ii-188-3dr-1.2-80hp-6984"
            });

            cars.Add(new Car()
            {
                Id = Guid.Parse("83f3d02f-e083-467f-a105-dc25ac02e3fa"),
                ManufacturerId = 5,
                ModelId = 88,
                ColorId = 3,
                ProvinceId = 13,
                Year = 2013,
                EngineId = 1,
                Odometer = 164000,
                TransmissionType = "Manual",
                EuroStandart = 5,
                CategoryId = 3,
                SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                TechnicalSpecificationURL = "https://www.auto-data.net/en/hyundai-ix35-1.7-crdi-115hp-18181"
            });

            cars.Add(new Car()
            {
                Id = Guid.Parse("61b85678-863c-48d6-9809-f426b78e6bfb"),
                ManufacturerId = 1,
                ModelId = 6,
                ColorId = 4,
                ProvinceId = 20,
                Year = 2008,
                EngineId = 4,
                Odometer = 160000,
                TransmissionType = "Automatic",
                EuroStandart = 5,
                CategoryId = 7,
                SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                City = "Sofia",
                Description = "This is my Audi A4 2008 wagon s-line trim",             
                TechnicalSpecificationURL = "https://www.auto-data.net/bg/audi-a4-avant-b8-8k-3.0-tdi-v6-240hp-quattro-4344"
            });

            cars.Add(new Car()
            {
                Id = Guid.Parse("2a42e928-40ec-4a02-b55e-694c229a6b81"),
                ManufacturerId = 28,
                ModelId = 350,
                ColorId = 10,
                ProvinceId = 20,
                Year = 2007,
                EngineId = 5,
                Odometer = 202000,
                TransmissionType = "Manual",
                EuroStandart = 4,
                CategoryId = 7,
                SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                City = "Sofia",
                Description = "Import from Switzerland. 4x4 with real 201000 km with catalytic converter. Works excellent.",
                TechnicalSpecificationURL = "https://www.auto-data.net/bg/skoda-octavia-ii-combi-2.0-fsi-150hp-4x4-14228"
            });

            return cars.ToArray();
        }
    }
}
