namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.RentPosts;

    public interface IRentService
    {
        public Task<ICollection<RentPostViewModel>> GetRentPostViewModelAsync();
    }
}
