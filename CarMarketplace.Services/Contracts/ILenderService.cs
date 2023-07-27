namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.User;

    public interface ILenderService
    {
        public Task<bool> LenderExistbyUserIdAsync(string userId);
        public Task<bool> LenderExistbyPhoneNumberAsync(string phoneNumber);
        public Task RegisterUserAsLenderAsync(string userId, UserPersonalnfoViewModel model);
    }
}
