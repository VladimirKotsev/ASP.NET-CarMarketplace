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
            ICollection<Car> cars = new HashSet<Car>
            {
                new Car()
                {
                    Id = Guid.Parse("864237e2-7f7a-469f-b019-697c848fc3aa"),
                    ManufacturerId = 1,
                    ModelId = 5,
                    ColorId = 2,
                    Year = 2009,
                    EngineId = 3,
                    Odometer = 209000,
                    TransmissionType = "Manual",
                    EuroStandart = 4,
                    CategoryId = 2,
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    TechnicalSpecificationURL = "https://www.auto-data.net/en/audi-a3-sportback-8pa-facelift-2008-1.9-tdi-105hp-dpf-4215"
                },

                new Car()
                {
                    Id = Guid.Parse("83f3d02f-e083-467f-a105-dc25ac02e3fa"),
                    ManufacturerId = 5,
                    ModelId = 88,
                    ColorId = 3,
                    Year = 2013,
                    EngineId = 1,
                    Odometer = 164000,
                    TransmissionType = "Manual",
                    EuroStandart = 5,
                    CategoryId = 3,
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    TechnicalSpecificationURL = "https://www.auto-data.net/en/hyundai-ix35-1.7-crdi-115hp-18181"
                },

                new Car()
                {
                    Id = Guid.Parse("61b85678-863c-48d6-9809-f426b78e6bfb"),
                    ManufacturerId = 1,
                    ModelId = 6,
                    ColorId = 4,
                    Year = 2008,
                    EngineId = 4,
                    Odometer = 160000,
                    TransmissionType = "Automatic",
                    EuroStandart = 5,
                    CategoryId = 7,
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    Description = "This is my Audi A4 2008 wagon s-line trim",
                    TechnicalSpecificationURL = "https://www.auto-data.net/bg/audi-a4-avant-b8-8k-3.0-tdi-v6-240hp-quattro-4344"
                },

                new Car()
                {
                    Id = Guid.Parse("2a42e928-40ec-4a02-b55e-694c229a6b81"),
                    ManufacturerId = 28,
                    ModelId = 350,
                    ColorId = 10,
                    Year = 2007,
                    EngineId = 5,
                    Odometer = 202000,
                    TransmissionType = "Manual",
                    EuroStandart = 4,
                    CategoryId = 7,
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    Description = "Import from Switzerland. 4x4 with real 201000 km with catalytic converter. Works excellent.",
                    TechnicalSpecificationURL = "https://www.auto-data.net/bg/skoda-octavia-ii-combi-2.0-fsi-150hp-4x4-14228"
                },

                new Car()
                {
                    Id = Guid.Parse("74483b38-f9ab-4deb-a155-2b04e9cfa647"),
                    ManufacturerId = 12,
                    ModelId = 166,
                    ColorId = 1,
                    Year = 2017,
                    EngineId = 6,
                    Odometer = 206600,
                    TransmissionType = "Automatic",
                    EuroStandart = 6,
                    CategoryId = 7,
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    Description = "Personal hybrid vehichle for sale.",
                },

                new Car()
                {
                    Id = Guid.Parse("35b8a5f3-59bd-4997-8b33-2c3b8381085f"),
                    ManufacturerId = 4,
                    ModelId = 64,
                    ColorId = 1,
                    Year = 1997,
                    EngineId = 7,
                    Odometer = 148000,
                    TransmissionType = "Manual",
                    EuroStandart = 3,
                    CategoryId = 3,
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    Description = "For sale is a car in excellent condition. I am the second owner. Imported from Italy 9 years ago. Always serviced on time and kept in a garage. It is not ridden in winter. No rust or rot. In the car, every system works without exception. A radio with a rear view camera for parking is integrated. Original alloy wheels for the model with good summer tires. There is also a set of winter tires on separate steel rims, which I never drove. Paid civil and examination. The car is fitted with gas injection and runs perfectly on both petrol and gas. With its three original keys - two black and one red service key. The original alarm system is working.",
                },

                new Car()
                {
                    Id = Guid.Parse("a7979b5b-0402-4c36-bd84-6e506464193d"),
                    ManufacturerId = 34,
                    ModelId = 403,
                    ColorId = 1,
                    Year = 2010,
                    EngineId = 8,
                    Odometer = 195000,
                    TransmissionType = "Manual",
                    EuroStandart = 5,
                    CategoryId = 2,
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    Description = "In a good shape.",
                }
            };

            return cars.ToArray();
        }
    }
}
