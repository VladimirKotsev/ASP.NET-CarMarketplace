namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; } = null!;

        public int ProvinceId { get; set; }

        [Required]
        [ForeignKey(nameof(ProvinceId))]
        public virtual Province Province { get; set; } = null!;

        public virtual ICollection<Seller> Sellers { get; set; } = null!;
    }
}
