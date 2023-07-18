﻿namespace CarMarketplace.Data.Models
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

        [ForeignKey(nameof(ManufacturerId))]
        [Required]
        public virtual CarManufacturer Make { get; set; }

        public int ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        [Required]
        public virtual CarModel Model { get; set; }

        public int ColorId { get; set; }

        [Required]
        public string City { get; set; } = null!;

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

        [Required]
        public string TransmissionType { get; set; } = null!;

        [Required]
        public int EuroStandart { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [Required]
        public virtual Category Category { get; set; } = null!;

        public Guid SellerId { get; set; }

        [Required]
        [ForeignKey(nameof(SellerId))]
        public virtual Seller Seller { get; set; } = null!;

        //Not required info about a car

        public string? TechnicalSpecificationURL { get; set; }

        public string? Description { get; set; }

        [MaxLength(VINNumberFixedLength)]
        public string? VinNumber { get; set; }
    }
}