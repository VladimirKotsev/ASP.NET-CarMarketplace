namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.RentPosts;
    using System;

    public interface IRentPostService
    {
        public Task AddPostAsync(AddRentPostViewModel viewModel, Guid lenderId);
        Task DeletePostAsync(Guid postId, Guid carId);
        public Task<AddRentPostViewModel> GetAddViewModelAsync(AddRentPostViewModel model);
    }
}
