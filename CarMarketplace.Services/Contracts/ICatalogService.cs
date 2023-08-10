namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Catalog;
    using CarMarketplace.Web.ViewModels.Common;

    public interface ICatalogService
    {
        public Task<ICollection<SalePostViewModel>> GetLatestSalePostsAsync();

        public Task<SearchViewModel> GetSearchViewModelAsync(SearchViewModel model);

        public Task<ICollection<SalePostViewModel>> GetFilteredSalePostsAsync(SearchViewModel model);

        public Task<ICollection<SalePostViewModel>> GetSalePostsByNationAsync(string group);
    }
}
