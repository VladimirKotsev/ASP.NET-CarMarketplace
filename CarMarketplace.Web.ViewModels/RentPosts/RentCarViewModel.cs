namespace CarMarketplace.Web.ViewModels.RentPosts
{
    using CarMarketplace.Web.ViewModels.Common;

    public class RentCarViewModel
    {
        public CarManufacturerViewModel Make { get; set; } = null!;

        public CarModelViewModel Model { get; set; } = null!;

        public ColorViewModel Color { get; set; } = null!;

        public int Year { get; set; }

        public int BootCapacity { get; set; }

        public int Seats { get; set; }

        public EngineViewModel Engine { get; set; } = null!;

        public string TransmissionType { get; set; } = null!;

        public int EuroStandart { get; set; }

        public CategoryViewModel Category { get; set; } = null!;
    }
}
