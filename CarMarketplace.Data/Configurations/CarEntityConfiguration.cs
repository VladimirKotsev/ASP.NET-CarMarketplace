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

        private Car[] GenerateCars()
        {
            ICollection<Car> cars = new HashSet<Car>();

            return cars.ToArray();
        }
    }
}
