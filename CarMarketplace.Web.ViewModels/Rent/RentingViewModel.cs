namespace CarMarketplace.Web.ViewModels.Rent
{
    using System.ComponentModel.DataAnnotations;

    using CarMarketplace.Web.ViewModels.RentPosts;
    using static CarMarketplace.Common.EntityValidations.Renter;
    public class RentingViewModel
    {
        public RentPostViewModel Post { get; set; } = null!;

        [Required]
        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberFixedLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public DateTime PickUpData { get; set; }
        
        [Required]
        public DateTime ReturnData { get; set; }
    }
}
