namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarMarketplace.Data.Models;
    using System.Reflection.Emit;

    public class SalePostApplicationUserConfiguration : IEntityTypeConfiguration<SalePostApplicationUsers>
    {
        public void Configure(EntityTypeBuilder<SalePostApplicationUsers> builder)
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
                .WithMany(sau => sau.Users)
                .HasForeignKey(sau => sau.SalePostId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
