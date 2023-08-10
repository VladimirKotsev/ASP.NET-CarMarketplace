namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SalePostApplicationUser
    {
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public Guid SalePostId { get; set; }

        [Required]
        [ForeignKey(nameof(SalePostId))]
        public SalePost SalePost { get; set; }

        public DateTime DateTimeAdded { get; set; }
    }
}
