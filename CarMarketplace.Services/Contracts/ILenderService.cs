namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Lender;

    public interface ILenderService
    {
        Task<bool> LenderExistbyPhoneNumberAsync(string phoneNumber);
        public Task<bool> LenderExistbyUserIdAsync(string userId);
        Task RegisterUserAsLenderAsync(string userId, LenderPersonalInfoViewModel model);
    }
}
