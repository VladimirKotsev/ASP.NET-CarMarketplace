namespace CarMarketplace.Web.ViewModels.User
{
    using CarMarketplace.Web.ViewModels.Lender;
    using CarMarketplace.Web.ViewModels.RentPosts;
    using System.ComponentModel.DataAnnotations;

    public class RentedViewModel
    {
        public Guid Id { get; set; }
        public RentCarViewModel Car { get; set; } = null!;

        public LenderViewModel Lender { get; set; } = null!;
        public decimal PricePerDay { get; set; }
        public string ImagePublicId { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string? Email { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public DateTime PickUpDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
