namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection.Metadata.Ecma335;

    public class RentPosts
    {
        public RentPosts()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        public Guid CarId { get; set; }

        [Required]
        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; } = null!;

        [Required]
        public int PricePerDay { get; set; }

        [Required]
        public int Days { get; set; }

        public double TotalPrice
        {
            get { return Days * PricePerDay; }
            set { }
        }


    }
}
