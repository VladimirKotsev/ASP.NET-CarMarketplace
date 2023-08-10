namespace CarMarketplace.Web.ViewModels.Common
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Mapping.Contracts;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}