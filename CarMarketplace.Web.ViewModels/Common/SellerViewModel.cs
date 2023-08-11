﻿namespace CarMarketplace.Web.ViewModels.Common
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Mapping.Contracts;

    public class SellerViewModel : IMapFrom<Seller>
    {
        public string PhoneNumber { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public CityViewModel City { get; set; } = null!;
    }
}