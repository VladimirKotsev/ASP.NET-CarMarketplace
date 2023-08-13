namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class RentCar
    {
        public RentCar()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        [Required]
        public virtual CarManufacturer Manufacturer { get; set; } = null!;

        public int ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        [Required]
        public virtual CarModel Model { get; set; } = null!;

        public int ColorId { get; set; }

        [ForeignKey(nameof(ColorId))]
        [Required]
        public virtual Color Color { get; set; } = null!;

        public int Year { get; set; }

        public int EngineId { get; set; }

        [Required]
        [ForeignKey(nameof(EngineId))]
        public virtual Engine Engine { get; set; } = null!;

        [Required]
        public string TransmissionType { get; set; } = null!;

        [Required]
        public int EuroStandart { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        public Guid RentPostId { get; set; }
        [Required]
        [ForeignKey(nameof(RentPostId))]
        public virtual RentPost RentPost { get; set; }
    }
}
