namespace CarMarketplace.Web.ViewModels.Common
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Mapping.Contracts;

    public class CarModelViewModel : IMapFrom<CarModel>
    {
        public int Id { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string ModelName { get; set; } = null!;
    }
}