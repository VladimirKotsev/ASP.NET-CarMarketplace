namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Catalog;

    public interface IUserService
    {
        public Task<ICollection<SalePostViewModel>> GetUserFavouritesAsync(string userId);
        public Task AddToUserFavouritesAsync(Guid postId, string userId);
    }
}
