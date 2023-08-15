namespace CarMarketplace.Web.ViewModels.Catalog
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using static CarMarketplace.Common.EntityValidations.Car;
    using static CarMarketplace.Common.EntityValidations.Engine;
    using static CarMarketplace.Common.EntityValidations.CarModel;
    using static CarMarketplace.Common.EntityValidations.Seller;
    using CarMarketplace.Web.ViewModels.Common;

    public class SearchViewModel
    {
        public ICollection<CarManufacturerViewModel>? Makes { get; set; }

        public ICollection<CategoryViewModel>? Categories { get; set; }

        public ICollection<ProvinceViewModel>? Provinces { get; set; }

        public int? Make { get; set; }

        [DisplayName("model")]
        [StringLength(ModelMaxLenght, MinimumLength = ModelMinLenght, ErrorMessage = ErrorMessage)]
        public string? ModelName { get; set; }
        public int? Category { get; set; }
        public int? ProvinceId { get; set; }

        [DisplayName("horsepower")]
        [Range(HorsepowerMinValue, HorsepowerMaxValue, ErrorMessage = ErrorMessage)]
        public int? FromHorsepower { get; set; }

        [DisplayName("horsepower")]
        [Range(HorsepowerMinValue, HorsepowerMaxValue, ErrorMessage = ErrorMessage)]
        public int? ToHorsepower { get; set; }

        [DisplayName("odometer kilometers")]
        [Range(OdometerMinValue, OdometerMaxValue, ErrorMessage = ErrorMessage)]
        public int? FromKilometers { get; set; }

        [DisplayName("odometer kilometers")]
        [Range(OdometerMinValue, OdometerMaxValue, ErrorMessage = ErrorMessage)]
        public int? ToKilometers { get; set; }

        [DisplayName("euro")]
        [Range(EuroStandartMinValue, EuroStandartMaxValue, ErrorMessage = ErrorMessage)]
        public int? FromEuro { get; set; }

        [DisplayName("year")]
        [Range(YearMinValue, YearMaxValue, ErrorMessage = ErrorMessage)]
        public int? FromYear { get; set; }

        [DisplayName("year")]
        [Range(YearMinValue, YearMaxValue, ErrorMessage = ErrorMessage)]
        public int? ToYear { get; set; }

        [DisplayName("city")]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength, ErrorMessage = ErrorMessage)]
        public string? City { get; set; }

        [DisplayName("price")]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = ErrorMessage)]
        public int? FromPrice { get; set; }

        [DisplayName("price")]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = ErrorMessage)]
        public int? ToPrice { get; set; }

        [DisplayName("transmission type")]
        public string? TransmissionType { get; set; }

        [DisplayName("engine")]
        public string? EngineFuelType { get; set; }
    }
}
