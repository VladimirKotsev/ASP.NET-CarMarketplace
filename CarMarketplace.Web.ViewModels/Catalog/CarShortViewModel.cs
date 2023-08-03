namespace CarMarketplace.Web.ViewModels.Catalog
{
    using System.ComponentModel.DataAnnotations;

    using CarMarketplace.Data.Models;

    public class CarShortViewModel
    {
        public Guid CarId { get; set; }

        [Required]
        public string MainPictureUrl { get; set; } = null!;

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public int CarYear { get; set; }

        [Required]
        public string CarMake { get; set; } = null!;

        [Required]
        public string CarModel { get; set; } = null!;

        [Required]
        public string CarName { get; set; } = null!;

        [Required]
        public string CarProvinceName { get; set; } = null!;

        [Required]
        public string CarTransmissionType { get; set; } = null!;

        [Required]
        public string CarEngineFuelType { get; set; } = null!;

        [Required]
        public int CarEngineDisplacement { get; set; }

        [Required]
        public int CarHorsepower { get; set; }
    }
}
