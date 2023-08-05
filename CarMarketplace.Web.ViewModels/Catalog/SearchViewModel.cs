namespace CarMarketplace.Web.ViewModels.Catalog
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidations.Car;
    using static Common.EntityValidations.Engine;
    using static Common.EntityValidations.CarModel;
    public class SearchViewModel
    {
        public ICollection<CarManufacturerViewModel>? Makes { get; set; }

        public ICollection<CarModelViewModel>? Models { get; set; }

        public ICollection<CategoryViewModel>? Categories { get; set; }

        public ICollection<ProvinceViewModel> Provinces { get; set; }

        [DisplayName("model")]
        [Range(ModelMinLenght, ModelMaxLenght, ErrorMessage = ErrorMessage)]
        public string? ModelName { get; set; }
        public int? Make { get; set; }
        public int? Category { get; set; }
        public int? ProvinceId { get; set; }

        [DisplayName("horsepower")]
        [Range(HorsepowerMinValue, HorsepowerMaxValue, ErrorMessage = ErrorMessage)]
        public int? FromHorsepower { get; set; }

        [DisplayName("horsepower")]
        [Range(HorsepowerMinValue, HorsepowerMaxValue, ErrorMessage = ErrorMessage)]
        public int? ToHorsepower { get; set; }

        [DisplayName("odometer")]
        [Range(OdometerMinLength, OdometerMaxLength, ErrorMessage = ErrorMessage)]
        public int? FromKilometers { get; set; }

        [DisplayName("odometer")]
        [Range(OdometerMinLength, OdometerMaxLength, ErrorMessage = ErrorMessage)]
        public int? ToKilometers { get; set; }
        public int? fromEuro { get; set; }

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
        [StringLength(TransmissionTypeMaxLength, MinimumLength = TransmissionTypeMinLength, ErrorMessage = ErrorMessage)]
        public string? TransmissionType { get; set; } = null!;

        [DisplayName("engine")]
        [StringLength(FuelTypeMaxLength, MinimumLength = FuelTypeMinLength, ErrorMessage = ErrorMessage)]
        public string? EngineFuelType { get; set; } = null!;
    }
}
