namespace CarMarketplace.Data.Configurations
{
    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RentPostEntityConfiguration : IEntityTypeConfiguration<RentPost>
    {
        public void Configure(EntityTypeBuilder<RentPost> builder)
        {
            builder
                .HasOne(x => x.Lender)
                .WithMany(x => x.LendedCars)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Lender)
                .WithMany(x => x.LendedCars)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Car)
                .WithOne(x => x.RentPost)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private RentPost[] GenerateRentPosts()
        {

            return null;
        }
    }
}
