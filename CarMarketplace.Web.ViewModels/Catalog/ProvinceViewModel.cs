namespace CarMarketplace.Web.ViewModels.Catalog
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Mapping.Contracts;

    public class ProvinceViewModel
    {
        public int Id { get; set; }

        public string ProvinceName { get; set; } = null!;
    }
}
