namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Rent;
    using CarMarketplace.Web.ViewModels.RentPosts;

    public interface IRentService
    {
        public Task<ICollection<RentPostViewModel>> GetRentPostViewModelAsync();

        public Task<RentingViewModel> GetRentingPostViewModel(Guid id, string userId);
        public Task RentVehicleAsync(string userId, Guid postId);
    }
}
