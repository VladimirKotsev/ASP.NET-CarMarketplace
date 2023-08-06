namespace CarMarketplace.Web.ViewModels.Catalog
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime;
    using static Common.EntityValidations.Car;
    using static Common.EntityValidations.Engine;

    public class AddCarForSaleViewModel
    {

        //httpGet data
        public ICollection<CarManufacturerViewModel> Makes { get; set; } = null!;
        public ICollection<CategoryViewModel> Categories { get; set; } = null!;
        public ICollection<ProvinceViewModel> Provinces { get; set; } = null!;
        public ICollection<ColorViewModel> Colors { get; set; } = null!;

        //httpPost data
        [Required]
        public int MakeId { get; set; }

        [Required]
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

        [Required]
        [Range(DisplacementMinValue, DisplacementMaxValue)]
        public int EngineDisplacement { get; set; }

        [Required]
        [StringLength(FuelTypeMaxLength, MinimumLength = FuelTypeMaxLength)]
        public string EngineFuelType { get; set; } = null!;

        [Required]
        [Range(HorsepowerMinValue, HorsepowerMaxValue)]
        public int EngineHorsePower { get; set; }

        public int Odometer { get; set; }

        [Required]
        public string TransmissionType { get; set; } = null!;

        [Required]
        public int EuroStandart { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string? TechnicalSpecificationURL { get; set; }

        [StringLength(VINNumberFixedLength)]
        public string? VinNumber { get; set; }

        [MinLength(DescriptionMinLength)]
        public string? Description { get; set; }

        [Required]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = ErrorMessage)]
        public int Price { get; set; }

        [Required]
        public ICollection<IFormFile> ImageUrls { get; set; } = null!;
    }
}
