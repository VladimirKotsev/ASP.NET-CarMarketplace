namespace CarMarketplace.Services.Contracts
{
    public interface ISellerService
    {
        public Task<bool> SellerExistbyUserIdAsync(string userId);
    }
}
