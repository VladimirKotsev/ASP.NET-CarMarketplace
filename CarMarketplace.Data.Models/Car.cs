namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    using static Common.EntityValidations.Car;

    public class Car
    {
        public Car()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public int ManufacturerId { get; set; }

        public int ModelId { get; set; }

        public int ColorId { get; set; }

        [ForeignKey(nameof(ColorId))]
        [Required]
        public virtual Color Color { get; set; } = null!;

        public int Year { get; set; }

        public int EngineId { get; set; }

        [ForeignKey(nameof(EngineId))]
        [Required]
        public virtual Engine Engine { get; set; } = null!;

        [Required]
        [MaxLength(OdometerMaxLength)]
        public string Odometer { get; set; } = null!;

        public int TransmissionId { get; set; }

        [Required]
        [ForeignKey(nameof(TransmissionId))]
        public virtual Transmission Transmission { get; set; } = null!;

        [Required]
        public int EuroStandart { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [Required]
        public virtual Category Category { get; set; } = null!;

        public int OwnerId { get; set; }
        public IdentityUser Owner { get; set; } = null!;

        [DataType("decimal")]
        public decimal Price { get; set; }

        //Not required info about a car

        public string? TechnicalSpecificationURL { get; set; }

        public string? Description { get; set; }

        [MaxLength(VINNumberFixedLength)]
        public string? VinNumber { get; set; }
    }
}