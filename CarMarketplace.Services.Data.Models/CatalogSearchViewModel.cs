namespace CarMarketplace.Services.Data.Models
{
    public class CatalogSearchViewModel
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int YearMin { get; set; }
        public int YearMax { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}