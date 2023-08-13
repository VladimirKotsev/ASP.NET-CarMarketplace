namespace CarMarketplace.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Net.NetworkInformation;
    using System.Runtime.ConstrainedExecution;
    public class RentPost
    {
        public RentPost()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        [Required]
        [ForeignKey(nameof(CarId))]
        public virtual RentCar Car { get; set; } = null!;

        public Guid LenderId { get; set; }

        [Required]
        [ForeignKey(nameof(LenderId))]
        public virtual Lender Lender{ get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        public Guid ClientId { get; set; }
        [Required]
        [ForeignKey(nameof(ClientId))]
        public ApplicationUser Client { get; set; }

        [DefaultValue(0)]
        [Required]
        public bool IsRented { get; set; }
    }
}
