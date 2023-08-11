namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EngineEntityConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.HasData(this.GenerateEngines());
        }

        //This method seeds data for engines in the database
        private Engine[] GenerateEngines()
        {
            ICollection<Engine> engines = new HashSet<Engine>();

            int id = 1;

            engines.Add(new Engine()
            {
                Id = id++,
                Displacement = 1700,
                Horsepower = 116,
                FuelType = "Diesel"
            });
            engines.Add(new Engine()
            {
                Id = id++,
                Displacement = 1200,
                Horsepower = 80,
                FuelType = "Petrol"
            });
            engines.Add(new Engine()
            {
                Id = id++,
                Displacement = 1900,
                Horsepower = 105,
                FuelType = "Diesel"
            });
            engines.Add(new Engine()
            {
                Id = id++,
                Displacement = 3000,
                Horsepower = 235,
                FuelType = "Diesel"
            });
            engines.Add(new Engine()
            {
                Id = id++,
                Displacement = 2000,
                Horsepower = 150,
                FuelType = "Petrol"
            });
            engines.Add(new Engine()
            {
                Id = id++,
                Displacement = 1800,
                Horsepower = 99,
                FuelType = "Hybrid"
            });
            engines.Add(new Engine()
            {
                Id = id++,
                Displacement = 1600,
                Horsepower = 126,
                FuelType = "Petrol"
            });
            engines.Add(new Engine()
            {
                Id = id++,
                Displacement = 1400,
                Horsepower = 170,
                FuelType = "Petrol"
            });

            return engines.ToArray();
        }
    }
}


