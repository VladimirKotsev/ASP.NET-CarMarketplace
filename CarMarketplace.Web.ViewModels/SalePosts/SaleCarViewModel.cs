namespace CarMarketplace.Web.ViewModels.Common
{
    using AutoMapper;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Services.Mapping.Contracts;
    using Data.Models;

    public class SaleCarViewModel : IMapFrom<SaleCar>
    {
        public Guid Id { get; set; }
        public CarManufacturerViewModel Make { get; set; } = null!;

        public CarModelViewModel Model { get; set; } = null!;

        public ColorViewModel Color { get; set; } = null!;

        public int Year { get; set; }

        public EngineViewModel Engine { get; set; } = null!;

        public int Odometer { get; set; }

        public string TransmissionType { get; set; } = null!;

        public int EuroStandart { get; set; }

        public CategoryViewModel Category { get; set; } = null!;

        public string? TechnicalSpecificationURL { get; set; }

        public string? Description { get; set; }

        public string? VinNumber { get; set; }
    }
}
