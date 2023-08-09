namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarMarketplace.Data.Models;
    using System.Reflection.Emit;

    public class SalePostApplicationUserConfiguration : IEntityTypeConfiguration<SalePostApplicationUser>
    {
        public void Configure(EntityTypeBuilder<SalePostApplicationUser> builder)
        {
            builder.HasKey(x => new
            {
                x.UserId,
                x.SalePostId
            });

            builder
                .HasOne(sau => sau.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(sau => sau.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(sau => sau.SalePost)
                .WithMany(sau => sau.SalePostUsers)
                .HasForeignKey(sau => sau.SalePostId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
