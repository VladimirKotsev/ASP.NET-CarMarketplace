namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidations.Seller;
    using static Common.EntityValidations.Lender;
    public class Lender
    {
        public Lender()
        {
            this.Id = Guid.NewGuid();
            this.LendedCars = new HashSet<RentPost>();
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberLegnth)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(CompanyNameMaxLength)]
        public string CompanyName { get; set; } = null!;

        public int CityId { get; set; }

        [Required]
        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        public virtual ICollection<RentPost> LendedCars { get; set; } = null!;
    }
}
