namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Engine
    {
        [Key]
        public int Id { get; set; }

        public int displacement { get; set; }

        public int Horsepower { get; set; }

        public double OilCapacity { get; set; }

        public double CoolantCapacity { get; set; }

        public int FuelTypeId { get; set; }

        [ForeignKey(nameof(FuelTypeId))]
        [Required]
        public virtual FuelType FuelType { get; set; } = null!;
    }
}