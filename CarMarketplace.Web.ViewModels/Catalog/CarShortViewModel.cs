namespace CarMarketplace.Web.ViewModels.Catalog
{
    using System.ComponentModel.DataAnnotations;

    using CarMarketplace.Data.Models;

    public class CarShortViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public Car Car { get; set; } = null!;

        [Required]
        public string MainPictureUrl { get; set; } = null!;

        public int Price { get; set; }

        public DateTime PublishDate { get; set; }

        public int CarYear { get; set; }

        [Required]
        public string CarMake { get; set; } = null!;

        [Required]
        public string CarModel { get; set; } = null!;

        [Required]
        public string CarName { get; set; } = null!;

        [Required]
        public string CarProvinceName { get; set; } = null!;
    }
}
