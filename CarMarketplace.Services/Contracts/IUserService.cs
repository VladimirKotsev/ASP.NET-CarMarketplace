namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.User;

    public interface IUserService
    {
        public Task<ICollection<FavouriteViewModel>> GetUserFavouritesAsync(string userId);
        public Task AddToUserFavouritesAsync(Guid postId, string userId);
        public Task<ICollection<Guid>> GetUserFavouritePostIdsAsync(string userId);
        public Task RemoveUserFavouritePostAsync(Guid postId, string userId);
    }
}
