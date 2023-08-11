namespace CarMarketplace.Web.ViewModels.Seller
{
    using System.ComponentModel.DataAnnotations;

    using static CarMarketplace.Common.EntityValidations.Users;

    public class SellerPersonalnfoViewModel
    {
        [Required]
        [StringLength(PhoneNumberLegnth, MinimumLength = PhoneNumberLegnth)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string City { get; set; } = null!;
    }
}
