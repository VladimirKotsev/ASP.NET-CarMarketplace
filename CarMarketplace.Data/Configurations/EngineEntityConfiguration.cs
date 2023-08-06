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
        //Please keep in mind the data is not fulfilled, It is for educational purposes
        private Engine[] GenerateEngines()
        {
            ICollection<Engine> engines = new HashSet<Engine>();

            int id = 1;

            //Diesel engines

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


            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1900,
            //    Horsepower = 130,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1900,
            //    Horsepower = 105,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 140,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1600,
            //    Horsepower = 130,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 140,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2100,
            //    Horsepower = 136,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 136,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1500,
            //    Horsepower = 101,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1600,
            //    Horsepower = 118,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1600,
            //    Horsepower = 130,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1700,
            //    Horsepower = 116,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 190,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1600,
            //    Horsepower = 160,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 150,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1600,
            //    Horsepower = 136,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1500,
            //    Horsepower = 115,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 3000,
            //    Horsepower = 330,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 3000,
            //    Horsepower = 400,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 3000,
            //    Horsepower = 235,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 240,
            //    FuelType = "Diesel"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 235,
            //    FuelType = "Diesel"
            //});

            ////Petrol engines

            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1000,
            //    Horsepower = 115,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1000,
            //    Horsepower = 140,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1200,
            //    Horsepower = 130,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1200,
            //    Horsepower = 130,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1200,
            //    Horsepower = 80,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 220,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 300,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 245,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 255,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1400,
            //    Horsepower = 150,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1400,
            //    Horsepower = 170,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1200,
            //    Horsepower = 116,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1500,
            //    Horsepower = 150,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1300,
            //    Horsepower = 140,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1500,
            //    Horsepower = 130,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1600,
            //    Horsepower = 177,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 228,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1800,
            //    Horsepower = 237,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2500,
            //    Horsepower = 186,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 2000,
            //    Horsepower = 152,
            //    FuelType = "Petrol"
            //});
            //engines.Add(new Engine()
            //{
            //    Id = id++,
            //    Displacement = 1500,
            //    Horsepower = 163,
            //    FuelType = "Petrol"
            //});

            return engines.ToArray();
        }
    }
}


