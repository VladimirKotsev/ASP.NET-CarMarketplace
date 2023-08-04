namespace CarMarketplace.Web.ViewModels.Catalog
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidations.Car;

    public class AddCarForSaleViewModel
    {

        //httpGet data
        public ICollection<CarManufacturerViewModel> Makes { get; set; } = null!;
        public ICollection<CarModelViewModel> Models { get; set; } = null!;
        public ICollection<EngineViewModel> Engines { get; set; } = null!;
        public ICollection<CategoryViewModel> Categories { get; set; } = null!;
        public ICollection<ProvinceViewModel> Provinces { get; set; } = null!;

        //httpPost data
        [Required]
        public int MakeId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        [Range(YearMinValue, YearMaxValue)]
        public int Year { get; set; }

        [Required]
        public int Price { get; set; }



        [MinLength(DescriptionMinLength)]
        public string? Description { get; set; }
    }
}
