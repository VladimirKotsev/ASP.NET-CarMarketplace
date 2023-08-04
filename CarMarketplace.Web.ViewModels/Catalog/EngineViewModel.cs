﻿namespace CarMarketplace.Web.ViewModels.Catalog
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Mapping.Contracts;

    public class EngineViewModel : IMapFrom<Engine>
    {
        public int Displacement { get; set; }

        public int Horsepower { get; set; }

        public string FuelType { get; set; } = null!;
    }
}