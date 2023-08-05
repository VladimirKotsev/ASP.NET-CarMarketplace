namespace CarMarketplace.Web.ViewModels.Catalog
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Mapping.Contracts;

    public class CarViewModel : IMapFrom<Car>
    {
        public CarManufacturerViewModel Make { get; set; } = null!;

        public CarModelViewModel Model { get; set; } = null!;

        public string CarName { get; set; } = null!;

        public string Color { get; set; } = null!;

        public ProvinceViewModel Province { get; set; } = null!;
        public string? City { get; set; }

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
