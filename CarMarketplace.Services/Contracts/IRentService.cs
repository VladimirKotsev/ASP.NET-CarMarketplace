namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Page;
    using CarMarketplace.Web.ViewModels.Rent;
    using CarMarketplace.Web.ViewModels.RentPosts;

    public interface IRentService
    {
        public Task<CatalogRentViewModel> GetRentPostViewModelAsync(int pageNum);
        public Task<RentingViewModel> GetRentingPostViewModelAsync(Guid id, string userId);
        public Task RentVehicleAsync(string userId, RentingViewModel model);
    }
}
