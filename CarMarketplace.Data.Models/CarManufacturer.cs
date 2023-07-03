namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidations.CarManufacturer;

    public class CarManufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ManufacturerMaxLength)]
        public string Name { get; set; } = null!;
    }
}
