namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Catalog;
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.Page;

    public interface ISaleService
    {
        public Task<ICollection<SalePostViewModel>> GetLatestSalePostsAsync();

        public Task<SearchViewModel> GetSearchViewModelAsync(SearchViewModel model);

        public Task<CatalogViewModel> GetFilteredSalePostsAsync(SearchViewModel model, int pageNum);

        public Task<CatalogViewModel> GetSalePostsByNationAsync(string group, int pageNum);
    }
}
