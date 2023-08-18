namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Lender;
    using CarMarketplace.Web.ViewModels.RentPosts;

    public interface ILenderService
    {
        Task<Guid> GetLenderIdByUserIdAsync(string userId);
        Task<ICollection<RentPostViewModel>> GetLenderPostsAsync(Guid lenderId);
        Task<bool> LenderExistbyPhoneNumberAsync(string phoneNumber);
        public Task<bool> LenderExistbyUserIdAsync(string userId);
        Task RegisterUserAsLenderAsync(string userId, LenderPersonalInfoViewModel model);
    }
}
