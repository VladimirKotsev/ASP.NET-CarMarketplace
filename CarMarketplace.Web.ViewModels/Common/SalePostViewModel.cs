namespace CarMarketplace.Web.ViewModels.Common
{

    public class SalePostViewModel
    {
        public Guid Id { get; set; }

        public CarViewModel Car { get; set; } = null!;

        public SellerViewModel Seller { get; set; } = null!;

        public int Price { get; set; }

        public DateTime PublishDate { get; set; }

        public string ImageUrls { get; set; } = null!;

        public int Likes { get; set; }

    }
}
