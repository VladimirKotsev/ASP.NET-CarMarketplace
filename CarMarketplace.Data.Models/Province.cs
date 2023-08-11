namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidations.Province;
    public class Province
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProvinceNameMaxLength)]
        public string ProvinceName { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; } = null!;
    }
}
