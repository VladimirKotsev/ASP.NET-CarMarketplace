namespace CarMarketplace.Web.ViewModels.RentPosts
{
    using CarMarketplace.Web.ViewModels.Lender;
    public class RentPostViewModel
    {
        public Guid Id { get; set; }
        public RentCarViewModel Car { get; set; } = null!;

        public LenderViewModel Lender { get; set; } = null!;
        public decimal PricePerDay { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ImagePublicId { get; set; } = null!;
        public bool IsRented { get; set; }
    }
}
