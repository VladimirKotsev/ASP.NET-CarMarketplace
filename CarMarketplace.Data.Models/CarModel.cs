namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidations.CarModel;

    public class CarModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public virtual CarManufacturer Manufacturer { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLenght)]
        public string ModelName { get; set; } = null!;
    }
}
