namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarMarketplace.Data.Models;

    public class SaleCarEntityConfiguration : IEntityTypeConfiguration<SaleCar>
    {
        public void Configure(EntityTypeBuilder<SaleCar> builder)
        {
            builder
                .HasOne(x => x.SalePost)
                .WithOne(x => x.Car)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(GenerateCars());
        }

        //This method seeds some example cars in the database
        private SaleCar[] GenerateCars()
        {
            ICollection<SaleCar> cars = new HashSet<SaleCar>
            {
                new SaleCar()
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
                    SalePostId = Guid.Parse("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                    TechnicalSpecificationURL = "https://www.auto-data.net/en/audi-a3-sportback-8pa-facelift-2008-1.9-tdi-105hp-dpf-4215"
                },

                new SaleCar()
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
                    SalePostId = Guid.Parse("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                    TechnicalSpecificationURL = "https://www.auto-data.net/en/hyundai-ix35-1.7-crdi-115hp-18181"
                },

                new SaleCar()
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
                    SalePostId = Guid.Parse("efe9de80-c4b1-478a-8b4e-9320bde47eb5"),
                    Description = "This is my Audi A4 2008 wagon s-line trim",
                    TechnicalSpecificationURL = "https://www.auto-data.net/bg/audi-a4-avant-b8-8k-3.0-tdi-v6-240hp-quattro-4344"
                },

                new SaleCar()
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
                    SalePostId = Guid.Parse("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"),
                    Description = "Import from Switzerland. 4x4 with real 201000 km with catalytic converter. Works excellent.",
                    TechnicalSpecificationURL = "https://www.auto-data.net/bg/skoda-octavia-ii-combi-2.0-fsi-150hp-4x4-14228"
                },

                new SaleCar()
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
                    SalePostId = Guid.Parse("2a84f9fc-7068-42a9-9dac-e49d33284196"),
                    Description = "Personal hybrid vehichle for sale.",
                },

                new SaleCar()
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
                    SalePostId = Guid.Parse("96b41a60-8da3-4a54-8422-5c570ae86705"),
                    Description = "For sale is a car in excellent condition. I am the second owner. Imported from Italy 9 years ago. Always serviced on time and kept in a garage. It is not ridden in winter. No rust or rot. In the car, every system works without exception. A radio with a rear view camera for parking is integrated. Original alloy wheels for the model with good summer tires. There is also a set of winter tires on separate steel rims, which I never drove. Paid civil and examination. The car is fitted with gas injection and runs perfectly on both petrol and gas. With its three original keys - two black and one red service key. The original alarm system is working.",
                },

                new SaleCar()
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
                    SalePostId = Guid.Parse("9597b286-3c2a-4fb5-85be-6625aebd2ec1"),
                    Description = "In a good shape.",
                }
            };

            return cars.ToArray();
        }
    }
}
