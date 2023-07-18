namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SalePosts
    {
        public SalePosts()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public virtual Seller User { get; set; } = null!;

        public Guid CarId { get; set; }

        [Required]
        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; } = null!;

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }
}
