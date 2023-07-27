namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.User;

    public interface ISellerService
    {
        public Task<bool> SellerExistbyUserIdAsync(string userId);
        public Task<bool> SellerExistbyPhoneNumberAsync(string phoneNumber);
        public Task RegisterUserAsSellerAsync(string userId, UserPersonalnfoViewModel model);
    }
}
