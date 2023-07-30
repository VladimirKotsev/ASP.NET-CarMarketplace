namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Web.ViewModels.Home;

    public interface IHomeService
    {
        public Task<ICollection<CarCardViewModel>> GetSalePostsAsync();
    }
}
