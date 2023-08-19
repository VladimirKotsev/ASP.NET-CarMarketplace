namespace CarMarketplace.Web.ViewModels.Rent
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using CarMarketplace.Web.ViewModels.RentPosts;
    using static CarMarketplace.Common.EntityValidations.Renter;
    public class RentingViewModel
    {
        public Guid PostId { get; set; }
        public RentPostViewModel? Post { get; set; }

        [Required]
        [DisplayName("full name")]
        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength)]
        public string FullName { get; set; } = null!;

        public string? Email { get; set; }

        [Required]
        [StringLength(PhoneNumberFixedLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public DateTime PickUpDate { get; set; }
        
        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
