namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class SellerEntityConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasData(this.GenerateSellers());
        }

        private Seller[] GenerateSellers()
        {
            ICollection<Seller> sellers = new HashSet<Seller>();

            sellers.Add(new Seller()
            {
                Id = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                UserId = Guid.Parse("EABA96E7-8AD5-436D-BE68-424370407635"),
                PhoneNumber = "0899904741",
                FirstName = "Vladimir",
                LastName = "Kotsev"
            });

            return sellers.ToArray();
        }
    }
}
