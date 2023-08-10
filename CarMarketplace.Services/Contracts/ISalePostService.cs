namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.SalePost;

    public interface ISalePostService
    {
        public Task<SalePostViewModel> GetSalePostByIdAsync(Guid postId);
        public Task<AddViewModel> GetAddPostViewModelAsync(AddViewModel viewModel);
        public Task AddPostAsync(AddViewModel viewModel, Guid sellerId);
        public Task<EditViewModel> GetEditViewModelByPostIdAsync(EditViewModel viewModel, Guid postId);
        public Task DeletePostAsync(Guid postId);

        public Task EditPostByIdAsync(EditViewModel viewModel);
    }
}
