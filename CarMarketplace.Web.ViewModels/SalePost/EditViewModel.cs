namespace CarMarketplace.Web.ViewModels.SalePost
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    using Microsoft.AspNetCore.Http;
    using static CarMarketplace.Common.EntityValidations.Car;
    using static CarMarketplace.Common.EntityValidations.Engine;
    using static CarMarketplace.Common.EntityValidations.Users;
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Services.Mapping.Contracts;
    using Microsoft.EntityFrameworkCore.Query.Internal;

    public class EditViewModel : IMapFrom<SalePostViewModel>
    {
        public EditViewModel()
        {
            this.Images = new HashSet<IFormFile>();
        }

        public ICollection<CarManufacturerViewModel>? Makes { get; set; }
        public ICollection<CategoryViewModel>? Categories { get; set; }
        public ICollection<ColorViewModel>? Colors { get; set; }

        public Guid? PostId { get; set; }

        public string? ImagesErrorMessage { get; set; }

        public string? ImageUrls { get; set; }

        public string? ThumbnailImageUrl { get; set; }

        [Required]
        public int MakeId { get; set; }

        [Required]
        public string Model { get; set; } = null!;

        [Required]
        public int ColorId { get; set; }

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
        [StringLength(FuelTypeMaxLength, MinimumLength = FuelTypeMinLength)]
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
        [StringLength(TransmissionTypeMaxLength, MinimumLength = TransmissionTypeMinLength, ErrorMessage = ErrorMessage)]
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

        public IFormFile ThumbnailImage { get; set; } = null!;

        public ICollection<IFormFile> Images { get; set; } = null!;
    }
}
