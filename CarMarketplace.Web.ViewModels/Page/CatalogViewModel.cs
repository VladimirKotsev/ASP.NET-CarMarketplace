namespace CarMarketplace.Web.ViewModels.Page
{
    using CarMarketplace.Web.ViewModels.Common;
    using System;
    public class CatalogViewModel
    {
        public CatalogViewModel()
        {
            this.SalePosts = new HashSet<SalePostViewModel>();
        }

        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<SalePostViewModel> SalePosts { get; set; }
    }
}

