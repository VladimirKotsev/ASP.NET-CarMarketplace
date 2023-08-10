namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Common;

    public interface IUserService
    {
        public Task<ICollection<SalePostViewModel>> GetUserFavouritesAsync(string userId);
        public Task AddToUserFavouritesAsync(Guid postId, string userId);
        public Task<ICollection<Guid>> GetUserFavouritePostIdsAsync(string userId);
        public Task RemoveUserFavouritePostAsync(Guid postId, string userId);
    }
}
