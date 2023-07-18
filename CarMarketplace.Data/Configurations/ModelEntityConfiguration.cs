namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ModelEntityConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder
                .HasMany(x => x.Cars)
                .WithOne(x => x.Model)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(this.GenerateHouses());
        }

        private CarModel[] GenerateHouses()
        {
            ICollection<CarModel> models = new HashSet<CarModel>();

            int id = 1;

            //Audi

            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "80"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "90"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "100"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A1"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A4"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A5"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A6"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A8"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "Q2"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "Q3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "Q5"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "Q7"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "Q8"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "TT"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "R8"
            });

            //BMW

            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "1 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "2 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "3 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "4 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "5 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "6 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "7 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "8 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X1"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X2"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X4"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X5"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X6"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X7"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "i3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "i8"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M1"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M2"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M4"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M5"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M6"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M8"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "Z1"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "Z3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "Z4"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "Z8"
            });

            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "Z8"
            });

            return models.ToArray();
        }
    }
}

