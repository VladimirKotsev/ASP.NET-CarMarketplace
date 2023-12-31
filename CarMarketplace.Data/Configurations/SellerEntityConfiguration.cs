﻿namespace CarMarketplace.Data.Configurations
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
            ICollection<Seller> sellers = new HashSet<Seller>
            {
                new Seller()
                {
                    Id = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    UserId = Guid.Parse("86B582F3-8998-43F1-A6C4-CC7F9E0EA91F"),
                    //Replace this with your auto generated user id copied from dto.AspNetUsers
                    CityId = 94,
                    PhoneNumber = "0899904741",
                    FirstName = "Vladimir",
                    LastName = "Kotsev"
                }
            };

            return sellers.ToArray();
        }
    }
}
