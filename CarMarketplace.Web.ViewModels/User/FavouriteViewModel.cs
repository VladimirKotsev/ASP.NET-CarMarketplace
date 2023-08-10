namespace CarMarketplace.Web.ViewModels.User
{
    using CarMarketplace.Web.ViewModels.Common;

    public class FavouriteViewModel
    {
        public SalePostViewModel SalePost { get; set; } = null!;

        public DateTime DateTimeAdded { get; set; }
    }
}
