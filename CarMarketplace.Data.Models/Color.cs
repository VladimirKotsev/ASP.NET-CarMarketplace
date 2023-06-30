namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
