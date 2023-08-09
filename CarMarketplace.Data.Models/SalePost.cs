namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SalePost
    {
        public SalePost()
        {
            this.Id = Guid.NewGuid();
            this.SalePostUsers = new HashSet<SalePostApplicationUser>();
        }
        public Guid Id { get; set; }

        public Guid SellerId { get; set; }

        [Required]
        [ForeignKey(nameof(SellerId))]
        public virtual Seller Seller { get; set; } = null!;

        public Guid CarId { get; set; }

        [Required]
        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; } = null!;

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(5000)")]
        public string ImageUrls { get; set; } = null!;

        public ICollection<SalePostApplicationUser> SalePostUsers { get; set; }
    }
}
