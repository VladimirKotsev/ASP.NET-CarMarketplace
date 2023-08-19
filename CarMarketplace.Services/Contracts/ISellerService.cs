namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.Page;
    using CarMarketplace.Web.ViewModels.Seller;

    public interface ISellerService
    {
        public Task<bool> SellerExistbyUserIdAsync(string userId);
        public Task<Guid> GetSellerIdByUserIdAsync(string userId);
        public Task<bool> SellerExistbyPhoneNumberAsync(string phoneNumber);
        public Task RegisterUserAsSellerAsync(string userId, SellerPersonalInfoViewModel model);
        public Task<CatalogViewModel> GetSellerPostsAsync(Guid sellerId, int pageNum);
        public Task<bool> CityExistByNameAsync(string name);
        public Task<ICollection<SalePostViewModel>> GetSellerArchivePostsAsync(Guid sellerId);
        public Task ActiveSellerPostAsync(Guid postId);
    }
}
