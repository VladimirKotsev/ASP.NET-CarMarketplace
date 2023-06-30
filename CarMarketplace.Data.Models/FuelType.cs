namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class FuelType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = null!;
    }
}