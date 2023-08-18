namespace CarMarketplace.Data.Configurations
{
    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RentCarEntityConfiguration : IEntityTypeConfiguration<RentCar>
    {
        public void Configure(EntityTypeBuilder<RentCar> builder)
        {
            builder.HasData(GenerateRentCars());
        }

        private RentCar[] GenerateRentCars()
        {
            ICollection<RentCar> rentCars = new HashSet<RentCar>();

            rentCars.Add(new RentCar()
            {
                Id = Guid.Parse("5ac9b2bb-a45f-45b6-be4c-47dd5c44a954"),
                BootCapacity = 45,
                CategoryId = 2,
                EuroStandart = 6,
                EngineId = 9,
                ManufacturerId = 8,
                ModelId = 116,
                Seats = 5,
                TransmissionType = "Manual",
                Year = 2016
            });

            return rentCars.ToArray();
        }
    }
}
