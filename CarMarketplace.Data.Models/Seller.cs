namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidations.Users;

    public class Seller
    {
        public Seller()
        {
            this.Id = Guid.NewGuid();
            this.CarOnSale = new HashSet<Car>();
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberLegnth)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Car> CarOnSale { get; set; } = null!;
    }
}
