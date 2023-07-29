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

            });

            return cars.ToArray();
        }
    }
}
