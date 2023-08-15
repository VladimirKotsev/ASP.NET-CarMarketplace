namespace CarMarketplace.Web.ViewModels.Lender
{
    using CarMarketplace.Data.Models;
    using CarMarketplace.Services.Mapping.Contracts;
    using CarMarketplace.Web.ViewModels.Common;

    public class LenderViewModel : IMapFrom<Lender>
    {
        public Guid Id { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public int CityId { get; set; }

        public virtual CityViewModel City { get; set; } = null!;

        public string Address { get; set; } = null!;
    }
}