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

        //This method generates one seller
        private Seller[] GenerateSellers()
        {
            ICollection<Seller> sellers = new HashSet<Seller>();

            sellers.Add(new Seller()
            {
                Id = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                UserId = Guid.Parse("4BB2AB54-4540-44C8-A4A5-49F005A7DA6E"),
                //Replace this with your auto generated user id copied from dto.AspNetUsers
                PhoneNumber = "0899904741",
                FirstName = "Vladimir",
                LastName = "Kotsev"
            });

            return sellers.ToArray();
        }
    }
}
