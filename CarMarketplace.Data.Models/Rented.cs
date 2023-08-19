namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using static CarMarketplace.Common.EntityValidations.Renter;

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

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; } = null!;

        public string? Email { get; set; }

        [Required]
        [MaxLength(PhoneNumberFixedLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public DateTime PickUpDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
