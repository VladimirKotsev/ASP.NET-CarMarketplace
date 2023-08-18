namespace CarMarketplace.Web.ViewModels.Lender
{
    using System.ComponentModel.DataAnnotations;

    using static CarMarketplace.Common.EntityValidations.Seller;
    using static CarMarketplace.Common.EntityValidations.Lender;
    public class LenderPersonalInfoViewModel
    {
        [Required]
        [StringLength(PhoneNumberLegnth, MinimumLength = PhoneNumberLegnth)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(CompanyNameMaxLength, MinimumLength = CompanyNameMinLength)]
        public string CompanyName { get; set; } = null!;

        [Required]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMaxLength)]
        public string Address { get; set; } = null!;
    }
}
