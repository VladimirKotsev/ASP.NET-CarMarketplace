namespace CarMarketplace.Services.Data.Models
{
    using CarMarketplace.Data.Models;

    public class CatalogSearchViewModel
    {
        public CatalogSearchViewModel()
        {
            this.Makes = new HashSet<CarManufacturer>();
            this.Models = new HashSet<CarModel>();
        }

        public ICollection<CarManufacturer> Makes { get; set; } = null!;
        public ICollection<CarModel>? Models { get; set; } = null!;
        public int YearMin { get; set; }
        public int YearMax { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}