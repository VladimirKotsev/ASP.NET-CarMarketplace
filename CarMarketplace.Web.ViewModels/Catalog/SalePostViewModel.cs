namespace CarMarketplace.Web.ViewModels.Catalog
{
    using CarMarketplace.Services.Mapping.Contracts;
    using CarMarketplace.Data.Models;
    using AutoMapper;

    public class SalePostViewModel : IMapFrom<SalePost>
    {
        public Guid Id { get; set; }

        public CarViewModel Car { get; set; } = null!;

        public SellerViewModel Seller { get; set; } = null!;

        public int Price { get; set; }

        public DateTime PublishDate { get; set; }

        public string ImageUrls { get; set; } = null!;

    }
}
