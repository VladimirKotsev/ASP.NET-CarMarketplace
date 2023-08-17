namespace CarMarketplace.Data.Configurations
{
    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RentedEntityConfiguration : IEntityTypeConfiguration<Rented>
    {
        public void Configure(EntityTypeBuilder<Rented> builder)
        {
            builder.HasKey(x => new { x.PostId, x.ClientId });
        }
    }
}
