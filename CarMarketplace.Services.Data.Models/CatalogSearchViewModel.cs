namespace CarMarketplace.Services.Data.Models
{
    using CarMarketplace.Data.Models;

    public class CatalogSearchViewModel
    {
        public List<CarManufacturer> Makes { get; set; } = null!;
        public List<CarModel>? Models { get; set; } = null!;
        public int YearMin { get; set; }
        public int YearMax { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}