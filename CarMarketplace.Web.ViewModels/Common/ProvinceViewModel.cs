namespace CarMarketplace.Web.ViewModels.Common
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Mapping.Contracts;

    public class ProvinceViewModel : IMapFrom<Province>
    {
        public int Id { get; set; }

        public string ProvinceName { get; set; } = null!;
    }
}
