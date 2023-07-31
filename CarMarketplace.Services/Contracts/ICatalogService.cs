namespace CarMarketplace.Services.Contracts
{
    using CarMarketplace.Web.ViewModels.Home;

    public interface ICatalogService
    {
        public Task<ICollection<CarShortViewModel>> GetLatestSalePostsAsync();
    }
}
