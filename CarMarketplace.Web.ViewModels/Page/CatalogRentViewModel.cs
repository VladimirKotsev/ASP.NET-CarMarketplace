namespace CarMarketplace.Web.ViewModels.Page
{
    using CarMarketplace.Web.ViewModels.RentPosts;

    public class CatalogRentViewModel
    {
        public CatalogRentViewModel()
        {
            RentPosts = new HashSet<RentPostViewModel>();
        }

        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<RentPostViewModel> RentPosts { get; set; }
    }
}
