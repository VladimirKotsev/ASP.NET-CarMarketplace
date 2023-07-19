namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ModelEntityConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder
                .HasMany(x => x.Cars)
                .WithOne(x => x.Model)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(this.GenerateHouses());
        }

        //This method seeds all data for car models in the database
        private CarModel[] GenerateHouses()
        {
            ICollection<CarModel> models = new HashSet<CarModel>();

            int id = 1;

            //Audi

            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "80"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "90"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "100"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A1"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A4"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A5"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A6"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "A8"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "Q2"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "Q3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "Q5"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "Q7"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "Q8"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "TT"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Audi",
                ModelName = "R8"
            });

            //BMW

            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "1 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "2 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "3 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "4 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "5 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "6 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "7 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "8 Series"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X1"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X2"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X4"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X5"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X6"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "X7"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "i3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "i8"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M1"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M2"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M4"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M5"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M6"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "M8"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "Z1"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "Z3"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "Z4"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "BMW",
                ModelName = "Z8"
            });

            //Mercedes-Benz

            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "A"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "B"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "C"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "CL"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "CLA"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "CLS"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "CLK"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "E"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "G"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "GLA"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "GLB"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "GLC"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "GLE"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "GLS"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "S"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "SL"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "S"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "GT"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Mercedes-Benz",
                ModelName = "ML"
            });

            //Honda

            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "Civic"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "Jazz"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "HR-V"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "CR-V"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "Accord"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "City"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "Insight"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "CR-Z"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "Legend"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "Odyssey"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "Integra"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Honda",
                ModelName = "S2000"
            });

            //Huyndai

            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "Accend"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "Coupe"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "Elantra"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "i10"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "i20"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "i30"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "i40"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "Tucson"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "Santa Fe"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "Ioniq"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "Veloster"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "ix20"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Huyndai",
                ModelName = "ix35"
            });

            //Ford
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Ford",
                ModelName = "Fiesta"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Ford",
                ModelName = "Focus"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Ford",
                ModelName = "Puma"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Ford",
                ModelName = "Kuga"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Ford",
                ModelName = "Mondeo"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Ford",
                ModelName = "Mustang"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Ford",
                ModelName = "C-MAX"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Ford",
                ModelName = "Escort"
            });

            //Nissan
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "Micra"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "Juke"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "Qashqai"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "X-Trail"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "Leaf"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "Murano"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "GT-R"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "200sx"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "240z"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "280z"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "300 zx"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "350z"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "370Z"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "Note"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "Terrano"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "Patrol"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "Skyline"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Nissan",
                ModelName = "Silvia"
            });

            //Renault

            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Renault",
                ModelName = "Clio"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Renault",
                ModelName = "Captur"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Renault",
                ModelName = "Megane"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Renault",
                ModelName = "Scenic"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Renault",
                ModelName = "Twingo"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Renault",
                ModelName = "Zoe"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Renault",
                ModelName = "Talisman"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Renault",
                ModelName = "Kangoo"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Renault",
                ModelName = "Espace"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Renault",
                ModelName = "Laguna"
            });

            //Peugeot

            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Peugeot",
                ModelName = "Espace"
            });
            models.Add(new CarModel
            {
                Id = id++,
                ManufacturerName = "Peugeot",
                ModelName = "Laguna"
            });

            return models.ToArray();
        }
    }
}

