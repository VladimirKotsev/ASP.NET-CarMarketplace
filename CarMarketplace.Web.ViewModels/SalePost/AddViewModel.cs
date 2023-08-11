namespace CarMarketplace.Web.ViewModels.SalePost
{
    using Microsoft.AspNetCore.Http;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using CarMarketplace.Web.ViewModels.Common;
    using static CarMarketplace.Common.EntityValidations.Car;
    using static CarMarketplace.Common.EntityValidations.Engine;
    using static CarMarketplace.Common.EntityValidations.Users;
    using static CarMarketplace.Common.EntityValidations.CarModel;

    public class AddViewModel
    {
        public ICollection<CarManufacturerViewModel>? Makes { get; set; }
        public ICollection<CategoryViewModel>? Categories { get; set; }
        public ICollection<ProvinceViewModel>? Provinces { get; set; }
        public ICollection<ColorViewModel>? Colors { get; set; }

        [Required]
        public int MakeId { get; set; }

        [Required]
        [DisplayName("model")]
        [StringLength(ModelMaxLenght, MinimumLength = ModelMinLenght, ErrorMessage = ErrorMessage)]
        public string Model { get; set; } = null!;

        [Required]
        public int ColorId { get; set; }

        [Required]
        public int ProvinceId { get; set; }

        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string? City { get; set; }

        [DisplayName("year")]
        [Required]
        [Range(YearMinValue, YearMaxValue, ErrorMessage = ErrorMessage)]
        public int Year { get; set; }

        [DisplayName("displacement")]
        [Required]
        [Range(DisplacementMinValue, DisplacementMaxValue)]
        public int EngineDisplacement { get; set; }

        [DisplayName("fuel type")]
        [Required]
        public string EngineFuelType { get; set; } = null!;

        [DisplayName("horsepower")]
        [Required]
        [Range(HorsepowerMinValue, HorsepowerMaxValue)]
        public int EngineHorsePower { get; set; }

        [DisplayName("odometer/kilometers")]
        [Range(OdometerMinValue, OdometerMaxValue, ErrorMessage = ErrorMessage)]
        public int Odometer { get; set; }

        [DisplayName("transmission")]
        [Required]
        public string TransmissionType { get; set; } = null!;

        [DisplayName("euro standart")]
        [Required]
        [Range(EuroStandartMinValue, EuroStandartMaxValue, ErrorMessage = ErrorMessage)]
        public int EuroStandart { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string? TechnicalSpecificationURL { get; set; }

        [DisplayName("vin")]
        [StringLength(VINNumberFixedLength, ErrorMessage = ErrorMessage)]
        public string? VinNumber { get; set; }

        [DisplayName("description")]
        [MinLength(DescriptionMinLength, ErrorMessage = ErrorMessage)]
        public string? Description { get; set; }

        [DisplayName("price")]
        [Required]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = ErrorMessage)]
        public int Price { get; set; }

        public ICollection<IFormFile> Images { get; set; } = null!;

        [Required]
        public IFormFile ThumbnailImage { get; set; } = null!;

        public string? ImagesErrorMessage { get; set; }
    }
}
