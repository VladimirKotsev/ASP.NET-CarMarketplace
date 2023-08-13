namespace CarMarketplace.Data.Configurations
{
    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LenderEntityConfiguration : IEntityTypeConfiguration<Lender>
    {
        public void Configure(EntityTypeBuilder<Lender> builder)
        {
            
        }

        private Lender[] GenerateLenders()
        {
            return null;
        }
    }
}
