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
                .WithOne(x => x.Make)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(this.GenerateHouses());
        }

        private CarManufacturer[] GenerateHouses()
        {
            ICollection<CarManufacturer> manufacturers = new HashSet<CarManufacturer>();

            manufacturers.Add(new CarManufacturer
            {
                Id = 1,
                Name = "Audi"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = 2,
                Name = "BMW"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = 3,
                Name = "Mercedes-benz"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = 4,
                Name = "Honda"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = 5,
                Name = "Huyndai"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = 6,
                Name = "Ford"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = 7,
                Name = "Nissan"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = 8,
                Name = "Renault"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = 9,
                Name = "Peugeot"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = 10,
                Name = "Fiat"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = 11,
                Name = "Opel"
            });

            manufacturers.Add(new CarManufacturer
            {
                Id = 12,
                Name = "Toyota"
            });

            return manufacturers.ToArray();
        }
    }
}
