namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.Seller;

    public interface ISellerService
    {
        public Task<bool> SellerExistbyUserIdAsync(string userId);
        public Task<Guid> GetSellerIdByUserIdAsync(string userId);
        public Task<bool> SellerExistbyPhoneNumberAsync(string phoneNumber);
        public Task RegisterUserAsSellerAsync(string userId, SellerPersonalnfoViewModel model);
        public Task<ICollection<SalePostViewModel>> GetSellerPostsAsync(Guid sellerId);
        

    }
}
