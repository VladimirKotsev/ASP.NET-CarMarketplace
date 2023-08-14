namespace CarMarketplace.Data.Configurations
{
    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LenderEntityConfiguration : IEntityTypeConfiguration<Lender>
    {
        public void Configure(EntityTypeBuilder<Lender> builder)
        {
            builder.HasData(GenerateLenders());
        }

        private Lender[] GenerateLenders()
        {
            ICollection<Lender> lenders = new HashSet<Lender>();

            lenders.Add(new Lender()
            {
                Id = Guid.Parse("a614c1dc-5f00-4549-82b3-2bc39de56c8f"),
                UserId = Guid.Parse("70094B5F-3F95-4D8A-BAA4-CA1B71633913"),
                CompanyName = "Rent Eood",
                PhoneNumber = "0889904740",
                Address = "Sofia Airport",
                CityId = 6,
            });

            return lenders.ToArray();
        }
    }
}
