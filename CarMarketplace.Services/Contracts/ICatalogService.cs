namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Catalog;

    public interface ICatalogService
    {
        public Task<ICollection<CarShortViewModel>> GetLatestSalePostsAsync();

        public Task<SearchViewModel> GetSearchViewModelAsync();
    }
}
