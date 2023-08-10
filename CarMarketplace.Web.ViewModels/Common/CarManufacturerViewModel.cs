namespace CarMarketplace.Web.ViewModels.Common
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Mapping.Contracts;

    public class CarManufacturerViewModel : IMapFrom<CarManufacturer>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
