namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Rented
    {
        public Guid ClientId { get; set; }
        [Required]
        [ForeignKey(nameof(ClientId))]
        public virtual ApplicationUser Client { get; set; } = null!;

        public Guid PostId { get; set; }
        [Required]
        [ForeignKey(nameof(PostId))]
        public virtual RentPost RentPost { get; set; } = null!;
    }
}
