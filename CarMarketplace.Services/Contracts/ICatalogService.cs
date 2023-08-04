namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Catalog;

    public interface ICatalogService
    {
        public Task<ICollection<SalePostViewModel>> GetLatestSalePostsAsync();

        public Task<SearchViewModel> GetSearchViewModelAsync();

        public Task<SalePostViewModel> GetSalePostByIdAsync(Guid postId);

        public Task<ICollection<CarModelViewModel>> GetModelsByMakeAsync(string make);
    }
}
