namespace CarMarketplace.Services.Contracts
{
    public interface ILenderService
    {
        public Task<bool> LenderExistbyUserIdAsync(string userId);
    }
}
