namespace CarMarketplace.Web.ViewModels.Common
{

    public class CityViewModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = null!;

        public ProvinceViewModel Province { get; set; } = null!;
    }
}