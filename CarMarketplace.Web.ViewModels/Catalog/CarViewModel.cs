namespace CarMarketplace.Web.ViewModels.Catalog
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Mapping.Contracts;

    public class CarViewModel : IMapFrom<Car>
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string CarName { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string Province { get; set; } = null!;
        public string? City { get; set; }

        public int Year { get; set; }

        public EngineViewModel Engine { get; set; } = null!;

        public string Odometer { get; set; } = null!;

        public string TransmissionType { get; set; } = null!;

        public int EuroStandart { get; set; }

        public string Category { get; set; } = null!;

        public string? TechnicalSpecificationURL { get; set; }

        public string? Description { get; set; }

        public string? VinNumber { get; set; }
        
    }
}
