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
                EngineId = 2,
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
                EngineId = 26,
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
                EngineId = 11,
                Odometer = 164000,
                TransmissionType = "Manual",
                EuroStandart = 5,
                CategoryId = 3,
                SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                TechnicalSpecificationURL = "https://www.auto-data.net/en/hyundai-ix35-1.7-crdi-115hp-18181"
            });

            return cars.ToArray();
        }
    }
}
