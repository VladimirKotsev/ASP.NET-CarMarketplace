namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Catalog;

    public interface ICatalogService
    {
        public Task<ICollection<SalePostViewModel>> GetLatestSalePostsAsync();

        public Task<SearchViewModel> GetSearchViewModelAsync(SearchViewModel model);

        public Task<SalePostViewModel> GetSalePostByIdAsync(Guid postId);

        public Task<ICollection<CarModelViewModel>> GetModelsByMakeAsync(string make);

        public Task<ICollection<SalePostViewModel>> GetFilteredSalePostsAsync(SearchViewModel model);

        public Task<AddCarForSaleViewModel> GetAddPostViewModelAsync(AddCarForSaleViewModel viewModel);

        public void AddPostAsync(AddCarForSaleViewModel viewModel, Guid sellerId);

        public void DeletePostAsync(Guid postId);
    }
}
