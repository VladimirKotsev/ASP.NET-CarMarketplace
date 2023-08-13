namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Engine
    {
        [Key]
        public int Id { get; set; }

        public int? Displacement { get; set; }

        public int Horsepower { get; set; }

        [Required]
        public string FuelType { get; set; } = null!;
    }
}