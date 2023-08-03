namespace CarMarketplace.Web.ViewModels.Catalog
{
    using CarMarketplace.Data.Models;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SearchViewModel
    {
        public ICollection<CarManufacturerViewModel> Makes { get; set; } = null!;

        public ICollection<CarModelViewModel> Models { get; set; } = null!;

        public ICollection<CategoryViewModel> Categories { get; set; } = null!;

        public ICollection<ProvinceViewModel> Provinces { get; set; } = null!;

        public int FromHorsepower { get; set; }
        public int ToHorsepower { get; set; }

        public int FromKilometers { get; set; }
        public int ToKilometers { get; set; }

        public int FromYear { get; set; }
        public int ToYear { get; set; }

        public int FromPrice { get; set; }
        public int ToPrice { get; set; }

        public string TransmissionType { get; set; } = null!;

        public string EngineType { get; set; } = null!;
    }
}
