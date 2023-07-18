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

            models.Add(new CarModel
            {
                Id = 1,
                ManufacturerId = 1,
                ModelName = "A4"
            });
            models.Add(new CarModel
            {
                Id = 2,
                ManufacturerId = 1,
                ModelName = "A5"
            });
            models.Add(new CarModel
            {
                Id = 3,
                ManufacturerId = 1,
                ModelName = "A6"
            });
            models.Add(new CarModel
            {
                Id = 4,
                ManufacturerId = 1,
                ModelName = "A3"
            });
            models.Add(new CarModel
            {
                Id = 5,
                ManufacturerId = 1,
                ModelName = "A8"
            });


            models.Add(new CarModel
            {
                Id = 6,
                ManufacturerId = 2,
                ModelName = "316"
            });
            models.Add(new CarModel
            {
                Id = 7,
                ManufacturerId = 2,
                ModelName = "320"
            });
            models.Add(new CarModel
            {
                Id = 8,
                ManufacturerId = 2,
                ModelName = "328"
            });
            models.Add(new CarModel
            {
                Id = 9,
                ManufacturerId = 2,
                ModelName = "320d"
            });
            models.Add(new CarModel
            {
                Id = 10,
                ManufacturerId = 2,
                ModelName = "530d"
            });

            return models.ToArray();
        }
    }
}

