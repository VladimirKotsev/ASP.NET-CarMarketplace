namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Lender;
    using CarMarketplace.Web.ViewModels.Page;
    using CarMarketplace.Web.ViewModels.RentPosts;

    public interface ILenderService
    {
        Task<Guid> GetLenderIdByUserIdAsync(string userId);
        Task<CatalogRentViewModel> GetLenderPostsAsync(Guid lenderId, int pageNum);
        Task<bool> LenderExistbyPhoneNumberAsync(string phoneNumber);
        public Task<bool> LenderExistbyUserIdAsync(string userId);
        Task RegisterUserAsLenderAsync(string userId, LenderPersonalInfoViewModel model);
    }
}
