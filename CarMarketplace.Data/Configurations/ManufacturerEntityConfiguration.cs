namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data.Models;

    public class ManufacturerEntityConfiguration : IEntityTypeConfiguration<CarManufacturer>
    {
        public void Configure(EntityTypeBuilder<CarManufacturer> builder)
        {
            builder
                .HasMany(x => x.Cars)
                .WithOne(x => x.Manufacturer)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(GenerateHouses());
        }

        //This method seeds data for car manufacturers/brands names in the database
        //Please keep in mind the data is not fulfilled, It is for educational purposes
        private static CarManufacturer[] GenerateHouses()
        {
            ICollection<CarManufacturer> manufacturers = new HashSet<CarManufacturer>();

            int id = 1;

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Audi"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "BMW"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Mercedes-Benz"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Honda"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Huyndai"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Ford"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Nissan"
            });

            manufacturers.Add(new CarManufacturer
            {
               Id = id++,
                Name = "Renault"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Peugeot"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Fiat"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Opel"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Toyota"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Chevrolet"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Jaguar"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Jeep"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Kia"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Lexus"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Porsche"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Subaru"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Volkswagen"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Volvo"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Citroën"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Dacia"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Land Rover"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Mazda"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Mini"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Seat"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Škoda"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Smart"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Suzuki"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Rolls-Royce"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Ferrari"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Lamborghini"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Alfa Romeo"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = id++,
                Name = "Lancia"
            });


            return manufacturers.ToArray();
        }
    }
}
