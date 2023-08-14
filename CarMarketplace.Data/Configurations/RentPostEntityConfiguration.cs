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

            builder.HasData(GenerateRentPosts());
        }

        private RentPost[] GenerateRentPosts()
        {
            ICollection<RentPost> posts = new HashSet<RentPost>();

            posts.Add(new RentPost()
            {
                Id = Guid.Parse("7475c229-d57d-48b5-a617-911727f9fbc7"),
                CarId = Guid.Parse("5ac9b2bb-a45f-45b6-be4c-47dd5c44a954"),
                PricePerDay = 78.23m,
                IsRented = false,
                LenderId = Guid.Parse("a614c1dc-5f00-4549-82b3-2bc39de56c8f")
            });

            return posts.ToArray();
        }
    }
}
