﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "Hatchback" },
                    { 3, "SUV" },
                    { 4, "Crossover" },
                    { 5, "Coupe" },
                    { 6, "Convertible" },
                    { 7, "Wagon/Estate" },
                    { 8, "Minivan" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 2, "White" },
                    { 3, "Gray" },
                    { 4, "Red" },
                    { 5, "Blue" },
                    { 6, "Green" },
                    { 7, "Yellow" },
                    { 8, "Orange" },
                    { 9, "Brown" },
                    { 10, "Beige" },
                    { 11, "Purple" },
                    { 12, "Pink" },
                    { 13, "Gold" },
                    { 14, "Bronze" },
                    { 15, "Navy" },
                    { 16, "Teal" },
                    { 17, "Burgundy" },
                    { 18, "Charcoal" },
                    { 19, "Cream" },
                    { 20, "Silver" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "Displacement", "FuelType", "Horsepower" },
                values: new object[,]
                {
                    { 1, 1700, "Diesel", 116 },
                    { 2, 1200, "Petrol", 80 },
                    { 3, 1900, "Diesel", 105 },
                    { 4, 3000, "Diesel", 235 },
                    { 5, 2000, "Petrol", 150 },
                    { 6, 1800, "Hybrid", 99 },
                    { 7, 1600, "Petrol", 126 },
                    { 8, 1400, "Petrol", 170 },
                    { 9, 1400, "Diesel", 90 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "BMW" },
                    { 3, "Mercedes-Benz" },
                    { 4, "Honda" },
                    { 5, "Huyndai" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Ford" },
                    { 7, "Nissan" },
                    { 8, "Renault" },
                    { 9, "Peugeot" },
                    { 10, "Fiat" },
                    { 11, "Opel" },
                    { 12, "Toyota" },
                    { 13, "Chevrolet" },
                    { 14, "Jaguar" },
                    { 15, "Jeep" },
                    { 16, "Kia" },
                    { 17, "Lexus" },
                    { 18, "Porsche" },
                    { 19, "Subaru" },
                    { 20, "Volkswagen" },
                    { 21, "Volvo" },
                    { 22, "Citroën" },
                    { 23, "Dacia" },
                    { 24, "Land Rover" },
                    { 25, "Mazda" },
                    { 26, "Mini" },
                    { 27, "Seat" },
                    { 28, "Škoda" },
                    { 29, "Smart" },
                    { 30, "Suzuki" },
                    { 31, "Rolls-Royce" },
                    { 32, "Ferrari" },
                    { 33, "Lamborghini" },
                    { 34, "Alfa Romeo" },
                    { 35, "Lancia" },
                    { 36, "Mitsubishi" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 1, "Audi", "80" },
                    { 2, "Audi", "90" },
                    { 3, "Audi", "100" },
                    { 4, "Audi", "A1" },
                    { 5, "Audi", "A3" },
                    { 6, "Audi", "A4" },
                    { 7, "Audi", "A5" },
                    { 8, "Audi", "A6" },
                    { 9, "Audi", "A8" },
                    { 10, "Audi", "Q2" },
                    { 11, "Audi", "Q3" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 12, "Audi", "Q5" },
                    { 13, "Audi", "Q7" },
                    { 14, "Audi", "Q8" },
                    { 15, "Audi", "TT" },
                    { 16, "Audi", "R8" },
                    { 17, "BMW", "1 Series" },
                    { 18, "BMW", "2 Series" },
                    { 19, "BMW", "3 Series" },
                    { 20, "BMW", "4 Series" },
                    { 21, "BMW", "5 Series" },
                    { 22, "BMW", "6 Series" },
                    { 23, "BMW", "7 Series" },
                    { 24, "BMW", "8 Series" },
                    { 25, "BMW", "X1" },
                    { 26, "BMW", "X2" },
                    { 27, "BMW", "X3" },
                    { 28, "BMW", "X4" },
                    { 29, "BMW", "X5" },
                    { 30, "BMW", "X6" },
                    { 31, "BMW", "X7" },
                    { 32, "BMW", "i3" },
                    { 33, "BMW", "i8" },
                    { 34, "BMW", "M1" },
                    { 35, "BMW", "M2" },
                    { 36, "BMW", "M3" },
                    { 37, "BMW", "M4" },
                    { 38, "BMW", "M5" },
                    { 39, "BMW", "M6" },
                    { 40, "BMW", "M8" },
                    { 41, "BMW", "Z1" },
                    { 42, "BMW", "Z3" },
                    { 43, "BMW", "Z4" },
                    { 44, "BMW", "Z8" },
                    { 45, "Mercedes-Benz", "A" },
                    { 46, "Mercedes-Benz", "B" },
                    { 47, "Mercedes-Benz", "C" },
                    { 48, "Mercedes-Benz", "CL" },
                    { 49, "Mercedes-Benz", "CLA" },
                    { 50, "Mercedes-Benz", "CLS" },
                    { 51, "Mercedes-Benz", "CLK" },
                    { 52, "Mercedes-Benz", "E" },
                    { 53, "Mercedes-Benz", "G" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 54, "Mercedes-Benz", "GLA" },
                    { 55, "Mercedes-Benz", "GLB" },
                    { 56, "Mercedes-Benz", "GLC" },
                    { 57, "Mercedes-Benz", "GLE" },
                    { 58, "Mercedes-Benz", "GLS" },
                    { 59, "Mercedes-Benz", "S" },
                    { 60, "Mercedes-Benz", "SL" },
                    { 61, "Mercedes-Benz", "S" },
                    { 62, "Mercedes-Benz", "GT" },
                    { 63, "Mercedes-Benz", "ML" },
                    { 64, "Honda", "Civic" },
                    { 65, "Honda", "Jazz" },
                    { 66, "Honda", "HR-V" },
                    { 67, "Honda", "CR-V" },
                    { 68, "Honda", "Accord" },
                    { 69, "Honda", "City" },
                    { 70, "Honda", "Insight" },
                    { 71, "Honda", "CR-Z" },
                    { 72, "Honda", "Legend" },
                    { 73, "Honda", "Odyssey" },
                    { 74, "Honda", "Integra" },
                    { 75, "Honda", "S2000" },
                    { 76, "Huyndai", "Accend" },
                    { 77, "Huyndai", "Coupe" },
                    { 78, "Huyndai", "Elantra" },
                    { 79, "Huyndai", "i10" },
                    { 80, "Huyndai", "i20" },
                    { 81, "Huyndai", "i30" },
                    { 82, "Huyndai", "i40" },
                    { 83, "Huyndai", "Tucson" },
                    { 84, "Huyndai", "Santa Fe" },
                    { 85, "Huyndai", "Ioniq" },
                    { 86, "Huyndai", "Veloster" },
                    { 87, "Huyndai", "ix20" },
                    { 88, "Huyndai", "ix35" },
                    { 89, "Ford", "Fiesta" },
                    { 90, "Ford", "Focus" },
                    { 91, "Ford", "Puma" },
                    { 92, "Ford", "Kuga" },
                    { 93, "Ford", "Mondeo" },
                    { 94, "Ford", "Mustang" },
                    { 95, "Ford", "C-MAX" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 96, "Ford", "Escort" },
                    { 97, "Nissan", "Micra" },
                    { 98, "Nissan", "Juke" },
                    { 99, "Nissan", "Qashqai" },
                    { 100, "Nissan", "X-Trail" },
                    { 101, "Nissan", "Leaf" },
                    { 102, "Nissan", "Murano" },
                    { 103, "Nissan", "GT-R" },
                    { 104, "Nissan", "200sx" },
                    { 105, "Nissan", "240z" },
                    { 106, "Nissan", "280z" },
                    { 107, "Nissan", "300 zx" },
                    { 108, "Nissan", "350z" },
                    { 109, "Nissan", "370Z" },
                    { 110, "Nissan", "Note" },
                    { 111, "Nissan", "Terrano" },
                    { 112, "Nissan", "Patrol" },
                    { 113, "Nissan", "Skyline" },
                    { 114, "Nissan", "Silvia" },
                    { 115, "Renault", "Clio" },
                    { 116, "Renault", "Captur" },
                    { 117, "Renault", "Megane" },
                    { 118, "Renault", "Scenic" },
                    { 119, "Renault", "Twingo" },
                    { 120, "Renault", "Zoe" },
                    { 121, "Renault", "Talisman" },
                    { 122, "Renault", "Kangoo" },
                    { 123, "Renault", "Espace" },
                    { 124, "Renault", "Laguna" },
                    { 125, "Peugeot", "1007" },
                    { 126, "Peugeot", "106" },
                    { 127, "Peugeot", "107" },
                    { 128, "Peugeot", "108" },
                    { 129, "Peugeot", "2008" },
                    { 130, "Peugeot", "206" },
                    { 131, "Peugeot", "207" },
                    { 132, "Peugeot", "208" },
                    { 133, "Peugeot", "3008" },
                    { 134, "Peugeot", "306" },
                    { 135, "Peugeot", "307" },
                    { 136, "Peugeot", "308" },
                    { 137, "Peugeot", "4007" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 138, "Peugeot", "4008" },
                    { 139, "Peugeot", "406" },
                    { 140, "Peugeot", "407" },
                    { 141, "Peugeot", "408" },
                    { 142, "Peugeot", "5008" },
                    { 143, "Peugeot", "508" },
                    { 144, "Peugeot", "Partner" },
                    { 145, "Fiat", "Punto" },
                    { 146, "Fiat", "Stilo" },
                    { 147, "Fiat", "500" },
                    { 148, "Fiat", "Panda" },
                    { 149, "Fiat", "Tipo" },
                    { 150, "Fiat", "500L" },
                    { 151, "Fiat", "Doblo" },
                    { 152, "Fiat", "Bravo" },
                    { 153, "Fiat", "Multipla" },
                    { 154, "Fiat", "Fiorino" },
                    { 155, "Opel", "Insignia" },
                    { 156, "Opel", "Astra" },
                    { 157, "Opel", "Corsa" },
                    { 158, "Opel", "Zafira" },
                    { 159, "Opel", "Mokka" },
                    { 160, "Opel", "Antara" },
                    { 161, "Opel", "GT" },
                    { 162, "Opel", "Meriva" },
                    { 163, "Opel", "Frontera" },
                    { 164, "Toyota", "Yaris" },
                    { 165, "Toyota", "Corolla" },
                    { 166, "Toyota", "Auris" },
                    { 167, "Toyota", "C-HR" },
                    { 168, "Toyota", "RAV4" },
                    { 169, "Toyota", "Land Cruiser" },
                    { 170, "Toyota", "Prius" },
                    { 171, "Toyota", "Camry" },
                    { 172, "Toyota", "Supra" },
                    { 173, "Toyota", "Avensis" },
                    { 174, "Toyota", "Verso" },
                    { 175, "Toyota", "Aygo" },
                    { 176, "Toyota", "GT86" },
                    { 177, "Toyota", "Hilux" },
                    { 178, "Toyota", "Carina" },
                    { 179, "Toyota", "Celica" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 180, "Chevrolet", "Spark" },
                    { 181, "Chevrolet", "Aveo" },
                    { 182, "Chevrolet", "Cruze" },
                    { 183, "Chevrolet", "Trax" },
                    { 184, "Chevrolet", "Captiva" },
                    { 185, "Chevrolet", "Orlando" },
                    { 186, "Chevrolet", "Corvette" },
                    { 187, "Chevrolet", "Camaro" },
                    { 188, "Chevrolet", "Matiz" },
                    { 189, "Chevrolet", "Tahoe" },
                    { 190, "Chevrolet", "Tacuma" },
                    { 191, "Jaguar", "XE" },
                    { 192, "Jaguar", "XF" },
                    { 193, "Jaguar", "XJ" },
                    { 194, "Jaguar", "F-Type" },
                    { 195, "Jaguar", "F-Pace" },
                    { 196, "Jaguar", "E-Pace" },
                    { 197, "Jaguar", "I-Pace" },
                    { 198, "Jaguar", "S-Type" },
                    { 199, "Jaguar", "X-Type" },
                    { 200, "Jaguar", "XJR" },
                    { 201, "Jeep", "Renegade" },
                    { 202, "Jeep", "Compass" },
                    { 203, "Jeep", "Cherokee" },
                    { 204, "Jeep", "Grand Cherokee" },
                    { 205, "Jeep", "Wrangler" },
                    { 206, "Jeep", "Gladiator" },
                    { 207, "Jeep", "Commander" },
                    { 208, "Jeep", "Patriot" },
                    { 209, "Jeep", "Grand Wagoneer" },
                    { 210, "Jeep", "Patriot" },
                    { 211, "Kia", "Picanto" },
                    { 212, "Kia", "Rio" },
                    { 213, "Kia", "Stonic" },
                    { 214, "Kia", "Soul" },
                    { 215, "Kia", "Ceed" },
                    { 216, "Kia", "Optima" },
                    { 217, "Kia", "Stinger" },
                    { 218, "Kia", "Seltos" },
                    { 219, "Kia", "Sportage" },
                    { 220, "Kia", "Sorento" },
                    { 221, "Kia", "Venga" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 222, "Lexus", "IS" },
                    { 223, "Lexus", "ES" },
                    { 224, "Lexus", "GS" },
                    { 225, "Lexus", "LS" },
                    { 226, "Lexus", "RX" },
                    { 227, "Lexus", "NX" },
                    { 228, "Lexus", "LC" },
                    { 229, "Porsche", "911" },
                    { 230, "Porsche", "718 Boxster" },
                    { 231, "Porsche", "718 Cayman" },
                    { 232, "Porsche", "Panamera" },
                    { 233, "Porsche", "Macan" },
                    { 234, "Porsche", "Cayenne" },
                    { 235, "Porsche", "Taycan" },
                    { 236, "Porsche", "959" },
                    { 237, "Porsche", "944" },
                    { 238, "Porsche", "911 GT2" },
                    { 239, "Porsche", "911 GT3" },
                    { 240, "Porsche", "911 Turbo" },
                    { 241, "Porsche", "911 Carrera 4S" },
                    { 242, "Subaru", "Impreza" },
                    { 243, "Subaru", "XV" },
                    { 244, "Subaru", "Forester" },
                    { 245, "Subaru", "Outback" },
                    { 246, "Subaru", "Legacy" },
                    { 247, "Subaru", "Levong" },
                    { 248, "Subaru", "WRX" },
                    { 249, "Subaru", "BRZ" },
                    { 250, "Subaru", "Ascent" },
                    { 251, "Volkswagen", "Polo" },
                    { 252, "Volkswagen", "Golf" },
                    { 253, "Volkswagen", "Passat" },
                    { 254, "Volkswagen", "Tiguan" },
                    { 255, "Volkswagen", "T-Roc" },
                    { 256, "Volkswagen", "Touran" },
                    { 257, "Volkswagen", "T-Cross" },
                    { 258, "Volkswagen", "Arteon" },
                    { 259, "Volkswagen", "Up!" },
                    { 260, "Volkswagen", "ID.3" },
                    { 261, "Volkswagen", "Jetta" },
                    { 262, "Volkswagen", "Sharan" },
                    { 263, "Volkswagen", "Scirocco" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 264, "Volkswagen", "Amarok" },
                    { 265, "Volkswagen", "Caddy" },
                    { 266, "Volkswagen", "Touareg" },
                    { 267, "Volkswagen", "Beetle" },
                    { 268, "Volvo", "XC60" },
                    { 269, "Volvo", "XC40" },
                    { 270, "Volvo", "XC90" },
                    { 271, "Volvo", "V60" },
                    { 272, "Volvo", "V40" },
                    { 273, "Volvo", "V90" },
                    { 274, "Volvo", "S60" },
                    { 275, "Volvo", "S90" },
                    { 276, "Volvo", "C30" },
                    { 277, "Volvo", "C70" },
                    { 278, "Volvo", "S40" },
                    { 279, "Volvo", "S80" },
                    { 280, "Volvo", "V50" },
                    { 281, "Volvo", "V70" },
                    { 282, "Citroën", "C2" },
                    { 283, "Citroën", "C3" },
                    { 284, "Citroën", "C3 Aircross" },
                    { 285, "Citroën", "C3 Picasso" },
                    { 286, "Citroën", "C4" },
                    { 287, "Citroën", "C4 Cactus" },
                    { 288, "Citroën", "C5" },
                    { 289, "Citroën", "C5 Aircross" },
                    { 290, "Citroën", "C6" },
                    { 291, "Citroën", "Berlingo" },
                    { 292, "Citroën", "DS3" },
                    { 293, "Citroën", "DS4" },
                    { 294, "Citroën", "DS5" },
                    { 295, "Citroën", "DS7" },
                    { 296, "Citroën", "Grand C4 Picasso" },
                    { 297, "Citroën", "C-Elysée" },
                    { 298, "Citroën", "Xsara Picasso" },
                    { 299, "Citroën", "Xsara" },
                    { 300, "Citroën", "ZX" },
                    { 301, "Dacia", "Sandero" },
                    { 302, "Dacia", "Sandero Stepway" },
                    { 303, "Dacia", "Logan" },
                    { 304, "Dacia", "Logan MCV" },
                    { 305, "Dacia", "Logan Stepway" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 306, "Dacia", "Duster" },
                    { 307, "Dacia", "Dokker" },
                    { 308, "Dacia", "Lodgy" },
                    { 309, "Land Rover", "Defender" },
                    { 310, "Land Rover", "Discovery" },
                    { 311, "Land Rover", "Discovery Sport" },
                    { 312, "Land Rover", "Range Rover" },
                    { 313, "Land Rover", "Range Rover Velar" },
                    { 314, "Land Rover", "Range Rover Sport" },
                    { 315, "Land Rover", "Range Rover Evoque" },
                    { 316, "Land Rover", "Freelander" },
                    { 317, "Mazda", "2" },
                    { 318, "Mazda", "3" },
                    { 319, "Mazda", "5" },
                    { 320, "Mazda", "6" },
                    { 321, "Mazda", "MX-5" },
                    { 322, "Mazda", "CX-3" },
                    { 323, "Mazda", "CX-30" },
                    { 324, "Mazda", "CX-5" },
                    { 325, "Mazda", "CX-9" },
                    { 326, "Mazda", "323" },
                    { 327, "Mazda", "626" },
                    { 328, "Mazda", "MX-3" },
                    { 329, "Mazda", "MX-6" },
                    { 330, "Mazda", "RX-7" },
                    { 331, "Mini", "Clubman" },
                    { 332, "Mini", "Cooper" },
                    { 333, "Mini", "Cooper" },
                    { 334, "Mini", "Cooper s" },
                    { 335, "Mini", "Countryman" },
                    { 336, "Mini", "Coupe" },
                    { 337, "Mini", "One" },
                    { 338, "Mini", "Paceman" },
                    { 339, "Seat", "Ibiza" },
                    { 340, "Seat", "Leon" },
                    { 341, "Seat", "Alhambra" },
                    { 342, "Seat", "Ateca" },
                    { 343, "Seat", "Arona" },
                    { 344, "Seat", "Tarraco" },
                    { 345, "Seat", "Toledo" },
                    { 346, "Seat", "Altea" },
                    { 347, "Seat", "Cupra" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 348, "Seat", "Fura" },
                    { 349, "Seat", "Vario" },
                    { 350, "Škoda", "Octavia" },
                    { 351, "Škoda", "Fabia" },
                    { 352, "Škoda", "Superb" },
                    { 353, "Škoda", "Kodiaq" },
                    { 354, "Škoda", "Karoq" },
                    { 355, "Škoda", "Scala" },
                    { 356, "Škoda", "Rapid" },
                    { 357, "Škoda", "Yeti" },
                    { 358, "Škoda", "Roomster" },
                    { 359, "Škoda", "Felicia" },
                    { 360, "Smart", "Fortwo" },
                    { 361, "Smart", "Forfour" },
                    { 362, "Smart", "Mc" },
                    { 363, "Smart", "Roadster" },
                    { 364, "Suzuki", "Swift" },
                    { 365, "Suzuki", "Ignis" },
                    { 366, "Suzuki", "Baleno" },
                    { 367, "Suzuki", "Celerio" },
                    { 368, "Suzuki", "Jimny" },
                    { 369, "Suzuki", "Vitara" },
                    { 370, "Suzuki", "S-Cross" },
                    { 371, "Suzuki", "Samurai" },
                    { 372, "Rolls-Royce", "Cullinan" },
                    { 373, "Rolls-Royce", "Dawm" },
                    { 374, "Rolls-Royce", "Ghost" },
                    { 375, "Rolls-Royce", "Phantom" },
                    { 376, "Rolls-Royce", "Rieju" },
                    { 377, "Rolls-Royce", "Silver Cloud" },
                    { 378, "Rolls-Royce", "Silver Seraph" },
                    { 379, "Rolls-Royce", "Silver Spur" },
                    { 380, "Rolls-Royce", "Wraith" },
                    { 381, "Rolls-Royce", "Phantom Limo" },
                    { 382, "Ferrari", "458 Italia" },
                    { 383, "Ferrari", "488 GTB" },
                    { 384, "Ferrari", "488 Spider" },
                    { 385, "Ferrari", "California T" },
                    { 386, "Ferrari", "Portofino" },
                    { 387, "Ferrari", "F12berlinetta" },
                    { 388, "Ferrari", "812 Superfast" },
                    { 389, "Ferrari", "GTC4Lusso" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 390, "Ferrari", "Roma" },
                    { 391, "Ferrari", "SF90 Stradale" },
                    { 392, "Lamborghini", "Huracán" },
                    { 393, "Lamborghini", "Aventador" },
                    { 394, "Lamborghini", "Urus" },
                    { 395, "Lamborghini", "Gallardo" },
                    { 396, "Lamborghini", "Diablo" },
                    { 397, "Lamborghini", "Veneno" },
                    { 398, "Lamborghini", "Centenario" },
                    { 399, "Lamborghini", "Sian" },
                    { 400, "Lamborghini", "Reventón" },
                    { 401, "Alfa Romeo", "Giulia" },
                    { 402, "Alfa Romeo", "Stelvio" },
                    { 403, "Alfa Romeo", "Giulietta" },
                    { 404, "Alfa Romeo", "4C" },
                    { 405, "Alfa Romeo", "MiTo" },
                    { 406, "Alfa Romeo", "159" },
                    { 407, "Alfa Romeo", "Brera" },
                    { 408, "Alfa Romeo", "147" },
                    { 409, "Alfa Romeo", "GT" },
                    { 410, "Alfa Romeo", "156" },
                    { 411, "Alfa Romeo", "GTV" },
                    { 412, "Alfa Romeo", "166" },
                    { 413, "Alfa Romeo", "33" },
                    { 414, "Alfa Romeo", "164" },
                    { 415, "Alfa Romeo", "155" },
                    { 416, "Alfa Romeo", "145" },
                    { 417, "Alfa Romeo", "146" },
                    { 418, "Lancia", "Aurelia" },
                    { 419, "Lancia", "Appia" },
                    { 420, "Lancia", "Fulvia" },
                    { 421, "Lancia", "Flaminia" },
                    { 422, "Lancia", "Stratos" },
                    { 423, "Lancia", "Delta" },
                    { 424, "Lancia", "Beta" },
                    { 425, "Lancia", "Gamma" },
                    { 426, "Lancia", "Montecarlo" },
                    { 427, "Lancia", "Thema" },
                    { 428, "Mitsubishi", "Outlander" },
                    { 429, "Mitsubishi", "ASX" },
                    { 430, "Mitsubishi", "L200" },
                    { 431, "Mitsubishi", "Eclipse Cross" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 432, "Mitsubishi", "Pajero" },
                    { 433, "Mitsubishi", "Space Star" },
                    { 434, "Mitsubishi", "Colt" },
                    { 435, "Mitsubishi", "Mirage" },
                    { 436, "Mitsubishi", "Shogun" },
                    { 437, "Mitsubishi", "Galant" },
                    { 438, "Mitsubishi", "Grandis" },
                    { 439, "Mitsubishi", "i-MiEV" },
                    { 440, "Mitsubishi", "Lancer" },
                    { 441, "Mitsubishi", "3000GT" },
                    { 442, "Mitsubishi", "Carisma" },
                    { 443, "Mitsubishi", "Evo" },
                    { 444, "Mitsubishi", "FTO" },
                    { 445, "Mitsubishi", "Celeste" },
                    { 446, "Mitsubishi", "Sapporo" },
                    { 447, "Mitsubishi", "Sigma" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "ProvinceName" },
                values: new object[,]
                {
                    { 1, "Blagoevgrad" },
                    { 2, "Burgas" },
                    { 3, "Dobrich" },
                    { 4, "Gabrovo" },
                    { 5, "Haskovo" },
                    { 6, "Kardzhali" },
                    { 7, "Kyustendil" },
                    { 8, "Lovech" },
                    { 9, "Montana" },
                    { 10, "Pazardzhik" },
                    { 11, "Pernik" },
                    { 12, "Pleven" },
                    { 13, "Plovdiv" },
                    { 14, "Razgrad" },
                    { 15, "Ruse" },
                    { 16, "Shumen" },
                    { 17, "Silistra" },
                    { 18, "Sliven" },
                    { 19, "Smolyan" },
                    { 20, "Sofia-City" },
                    { 21, "Sofia" },
                    { 22, "Stara Zagora" },
                    { 23, "Targovishte" },
                    { 24, "Varna" },
                    { 25, "Veliko Tarnovo" },
                    { 26, "Vidin" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "ProvinceName" },
                values: new object[] { 27, "Vratsa" });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "ProvinceName" },
                values: new object[] { 28, "Yambol" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Bansko", 1 },
                    { 2, "Blagoevgrad", 1 },
                    { 3, "Gotse Delchev", 1 },
                    { 4, "Petrich", 1 },
                    { 5, "Razlog", 1 },
                    { 6, "Sandanski", 1 },
                    { 7, "Belitsa", 1 },
                    { 8, "Kresna", 1 },
                    { 9, "Simitli", 1 },
                    { 10, "Strumyani", 1 },
                    { 11, "Yakoruda", 1 },
                    { 12, "Velingrad", 1 },
                    { 13, "Garmen", 1 },
                    { 14, "Dobrinishte", 1 },
                    { 15, "Rila", 1 },
                    { 16, "Kocherinovo", 1 },
                    { 17, "Satovcha", 1 },
                    { 18, "Hadzhidimovo", 1 },
                    { 19, "Aytos", 2 },
                    { 20, "Burgas", 2 },
                    { 21, "Balgarovo", 2 },
                    { 22, "Bratovo", 2 },
                    { 23, "Bryastovets", 2 },
                    { 24, "Bŭlgari", 2 },
                    { 25, "Dimchevo", 2 },
                    { 26, "Drachevo", 2 },
                    { 27, "Dyulevo", 2 },
                    { 28, "Gabar", 2 },
                    { 29, "Golyamo Bukovo", 2 },
                    { 30, "Gorno Ezerovo", 2 },
                    { 31, "Izgrev", 2 },
                    { 32, "Kableshkovo", 2 },
                    { 33, "Kameno", 2 },
                    { 34, "Karnobat", 2 },
                    { 35, "Kiten", 2 },
                    { 36, "Konstantinovo", 2 },
                    { 37, "Kosharitsa", 2 },
                    { 38, "Krŭstina", 2 },
                    { 39, "Livada", 2 },
                    { 40, "Malko Tarnovo", 2 },
                    { 41, "Marinka", 2 },
                    { 42, "Mirolyubovo", 2 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "ProvinceId" },
                values: new object[,]
                {
                    { 43, "Nesebar", 2 },
                    { 44, "Obzor", 2 },
                    { 45, "Pomorie", 2 },
                    { 46, "Primorsko", 2 },
                    { 47, "Ravda", 2 },
                    { 48, "Rosen", 2 },
                    { 49, "Rudnik", 2 },
                    { 50, "Rusokastro", 2 },
                    { 51, "Sadievo", 2 },
                    { 52, "Slanchevo", 2 },
                    { 53, "Sozopol", 2 },
                    { 54, "Sredets", 2 },
                    { 55, "Stratsin", 2 },
                    { 56, "Sŭdievo", 2 },
                    { 57, "Sungurlare", 2 },
                    { 58, "Svetlina", 2 },
                    { 59, "Svoboda", 2 },
                    { 60, "Tsarevo", 2 },
                    { 61, "Tvarditsa", 2 },
                    { 62, "Varovnik", 2 },
                    { 63, "Vedrovo", 2 },
                    { 64, "Veselie", 2 },
                    { 65, "Vizitsa", 2 },
                    { 66, "Vŭrgotch", 2 },
                    { 67, "Yasna Polyana", 2 },
                    { 68, "Dobrich", 3 },
                    { 69, "Balchik", 3 },
                    { 70, "General Toshevo", 3 },
                    { 71, "Kavarna", 3 },
                    { 72, "Shabla", 3 },
                    { 73, "Tervel", 3 },
                    { 74, "Krushari", 3 },
                    { 75, "Gabrovo", 4 },
                    { 76, "Sevlievo", 4 },
                    { 77, "Dryanovo", 4 },
                    { 78, "Tryavna", 4 },
                    { 79, "Haskovo", 5 },
                    { 80, "Dimitrovgrad", 5 },
                    { 81, "Svilengrad", 5 },
                    { 82, "Harmanli", 5 },
                    { 83, "Topolovgrad", 5 },
                    { 84, "Ivaylovgrad", 5 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "ProvinceId" },
                values: new object[,]
                {
                    { 85, "Lyubimets", 5 },
                    { 86, "Madzharovo", 5 },
                    { 87, "Mineralni Bani", 5 },
                    { 88, "Kardzhali", 6 },
                    { 89, "Momchilgrad", 6 },
                    { 90, "Ardino", 6 },
                    { 91, "Krumovgrad", 6 },
                    { 92, "Dzhebel", 6 },
                    { 93, "Kirkovo", 6 },
                    { 94, "Kyustendil", 7 },
                    { 95, "Boboshevo", 7 },
                    { 96, "Brezovo", 7 },
                    { 97, "Dupnitsa", 7 },
                    { 98, "Sapareva Banya", 7 },
                    { 99, "Zemen", 7 },
                    { 100, "Lovech", 8 },
                    { 101, "Apriltsi", 8 },
                    { 102, "Letnitsa", 8 },
                    { 103, "Lukovit", 8 },
                    { 104, "Teteven", 8 },
                    { 105, "Yablanitsa", 8 },
                    { 106, "Ugarchin", 8 },
                    { 107, "Troyan", 8 },
                    { 108, "Montana", 9 },
                    { 109, "Berkovitsa", 9 },
                    { 110, "Boychinovtsi", 9 },
                    { 111, "Brusartsi", 9 },
                    { 112, "Chiprovtsi", 9 },
                    { 113, "Georgi Damyanovo", 9 },
                    { 114, "Lom", 9 },
                    { 115, "Valchedram", 9 },
                    { 116, "Yakimovo", 9 },
                    { 117, "Pazardzhik", 10 },
                    { 118, "Belovo", 10 },
                    { 119, "Panagyurishte", 10 },
                    { 120, "Plovdivtsi", 10 },
                    { 121, "Strelcha", 10 },
                    { 122, "Septemvri", 10 },
                    { 123, "Rakitovo", 10 },
                    { 124, "Velingrad", 10 },
                    { 125, "Pernik", 11 },
                    { 126, "Radomir", 11 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "ProvinceId" },
                values: new object[,]
                {
                    { 127, "Batanovtsi", 11 },
                    { 128, "Breznik", 11 },
                    { 129, "Pleven", 12 },
                    { 130, "Dolni Dabnik", 12 },
                    { 131, "Gulyantsi", 12 },
                    { 132, "Levski", 12 },
                    { 133, "Nikopol", 12 },
                    { 134, "Cherven Bryag", 12 },
                    { 135, "Plovdiv", 13 },
                    { 136, "Asenovgrad", 13 },
                    { 137, "Rakovski", 13 },
                    { 138, "Karlovo", 13 },
                    { 139, "Parvomay", 13 },
                    { 140, "Sadovo", 13 },
                    { 141, "Hisarya", 13 },
                    { 142, "Perushtitsa", 13 },
                    { 143, "Saedinenie", 13 },
                    { 144, "Kuklen", 13 },
                    { 145, "Sopot", 13 },
                    { 146, "Krichim", 13 },
                    { 147, "Rozino", 13 },
                    { 148, "Laki", 13 },
                    { 149, "Stamboliyski", 13 },
                    { 150, "Razgrad", 14 },
                    { 151, "Isperih", 14 },
                    { 152, "Loznitsa", 14 },
                    { 153, "Samuil", 14 },
                    { 154, "Tsar Kaloyan", 14 },
                    { 155, "Zavet", 14 },
                    { 156, "Ruse", 15 },
                    { 157, "Borovo", 15 },
                    { 158, "Dve Mogili", 15 },
                    { 159, "Ivanovo", 15 },
                    { 160, "Slivo Pole", 15 },
                    { 161, "Tsenovo", 15 },
                    { 162, "Shumen", 16 },
                    { 163, "Kaspichan", 16 },
                    { 164, "Novi Pazar", 16 },
                    { 165, "Veliki Preslav", 16 },
                    { 166, "Varbitsa", 16 },
                    { 167, "Silistra", 17 },
                    { 168, "Alfatar", 17 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "ProvinceId" },
                values: new object[,]
                {
                    { 169, "Dulovo", 17 },
                    { 170, "Glavinitsa", 17 },
                    { 171, "Kaynardzha", 17 },
                    { 172, "Sitovo", 17 },
                    { 173, "Tutrakan", 17 },
                    { 174, "Sliven", 18 },
                    { 175, "Kotel", 18 },
                    { 176, "Nova Zagora", 18 },
                    { 177, "Tvarditsa", 18 },
                    { 178, "Smolyan", 19 },
                    { 179, "Chepelare", 19 },
                    { 180, "Devin", 19 },
                    { 181, "Dospat", 19 },
                    { 182, "Madan", 19 },
                    { 183, "Rudozem", 19 },
                    { 184, "Zlatograd", 19 },
                    { 185, "Sofia", 20 },
                    { 186, "Bankya", 21 },
                    { 187, "Botevgrad", 21 },
                    { 188, "Elin Pelin", 21 },
                    { 189, "Etropole", 21 },
                    { 190, "Gorna Malina", 21 },
                    { 191, "Ihtiman", 21 },
                    { 192, "Kostenets", 21 },
                    { 193, "Kostinbrod", 21 },
                    { 194, "Mirkovo", 21 },
                    { 195, "Pirdop", 21 },
                    { 196, "Pravets", 21 },
                    { 197, "Samokov", 21 },
                    { 198, "Slivnitsa", 21 },
                    { 199, "Stara Zagora", 22 },
                    { 200, "Chirpan", 22 },
                    { 201, "Galabovo", 22 },
                    { 202, "Gurkovo", 22 },
                    { 203, "Kazanlak", 22 },
                    { 204, "Maglizh", 22 },
                    { 205, "Nikolaevo", 22 },
                    { 206, "Opan", 22 },
                    { 207, "Radnevo", 22 },
                    { 208, "Shipka", 22 },
                    { 209, "Targovishte", 23 },
                    { 210, "Omurtag", 23 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "ProvinceId" },
                values: new object[,]
                {
                    { 211, "Antonovo", 23 },
                    { 212, "Opaka", 23 },
                    { 213, "Popovo", 23 },
                    { 214, "Varna", 24 },
                    { 215, "Aksakovo", 24 },
                    { 216, "Avren", 24 },
                    { 217, "Beloslav", 24 },
                    { 218, "Byala", 24 },
                    { 219, "Devnya", 24 },
                    { 220, "Dolni Chiflik", 24 },
                    { 221, "Dalgopol", 24 },
                    { 222, "Provadia", 24 },
                    { 223, "Suvorovo", 24 },
                    { 224, "Veliko Tarnovo", 25 },
                    { 225, "Elena", 25 },
                    { 226, "Gorna Oryahovitsa", 25 },
                    { 227, "Lyaskovets", 25 },
                    { 228, "Pavlikeni", 25 },
                    { 229, "Svishtov", 25 },
                    { 230, "Strazhitsa", 25 },
                    { 231, "Suhindol", 25 },
                    { 232, "Vidin", 26 },
                    { 233, "Belogradchik", 26 },
                    { 234, "Bregovo", 26 },
                    { 235, "Boynitsa", 26 },
                    { 236, "Gramada", 26 },
                    { 237, "Dimovo", 26 },
                    { 238, "Kula", 26 },
                    { 239, "Vratsa", 27 },
                    { 240, "Borovan", 27 },
                    { 241, "Boychinovtsi", 27 },
                    { 242, "Byala Slatina", 27 },
                    { 243, "Kozloduy", 27 },
                    { 244, "Mezdra", 27 },
                    { 245, "Mizia", 27 },
                    { 246, "Roman", 27 },
                    { 247, "Hayredin", 27 },
                    { 248, "Hristo Danovo", 27 },
                    { 249, "Yambol", 28 },
                    { 250, "Bolyarovo", 28 },
                    { 251, "Elhovo", 28 },
                    { 252, "Straldzha", 28 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "ProvinceId" },
                values: new object[] { 253, "Tundzha", 28 });

            migrationBuilder.InsertData(
                table: "RentCars",
                columns: new[] { "Id", "BootCapacity", "CategoryId", "ColorId", "EngineId", "EuroStandart", "ManufacturerId", "ModelId", "RentPostId", "Seats", "TransmissionType", "Year" },
                values: new object[] { new Guid("5ac9b2bb-a45f-45b6-be4c-47dd5c44a954"), 45, 2, 3, 9, 6, 8, 116, new Guid("00000000-0000-0000-0000-000000000000"), 5, "Manual", 2016 });

            migrationBuilder.InsertData(
                table: "Lenders",
                columns: new[] { "Id", "Address", "CityId", "CompanyName", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("a614c1dc-5f00-4549-82b3-2bc39de56c8f"), "Sofia Airport", 6, "Rent Eood", "0889904740", new Guid("90254096-594a-4e13-9718-7af72d0132ee") });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "CityId", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), 94, "Vladimir", "Kotsev", "0899904741", new Guid("86b582f3-8998-43f1-a6c4-cc7f9e0ea91f") });

            migrationBuilder.InsertData(
                table: "RentPosts",
                columns: new[] { "Id", "CarId", "CreatedOn", "ImagePublicId", "IsRented", "LenderId", "PricePerDay" },
                values: new object[] { new Guid("7475c229-d57d-48b5-a617-911727f9fbc7"), new Guid("5ac9b2bb-a45f-45b6-be4c-47dd5c44a954"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "v1692020397/Renault-Clio-2017-1280-04_imukgz.jpg", false, new Guid("a614c1dc-5f00-4549-82b3-2bc39de56c8f"), 78.23m });

            migrationBuilder.InsertData(
                table: "SalePosts",
                columns: new[] { "Id", "CarId", "CreatedOn", "ImagePublicIds", "IsDeleted", "Price", "SellerId", "ThumbnailImagePublicId" },
                values: new object[,]
                {
                    { new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"), new Guid("83f3d02f-e083-467f-a105-dc25ac02e3fa"), new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2841), "v1690705040/64c11d4d7f1d92d2780184a3o_wdzk9m.jpg, v1690705038/64c11d507f1d92d2780184a4o_sedhtb.jpg, v1690705038/64c37299fc2825af7307f104o_wbbnrh.jpg, v1690705038/64c11d5e0ccd31ea250803b2o_j83454.jpg", false, 17000, new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), "v1690705038/64c11d4911a396d9060766d2o_j0myw0.jpg" },
                    { new Guid("2a84f9fc-7068-42a9-9dac-e49d33284196"), new Guid("74483b38-f9ab-4deb-a155-2b04e9cfa647"), new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2865), "v1691646412/64d3fb46c29439437a06b363o_qwemd9.jpg, v1691646412/64d3fb483eb36bd7480a5833b_tmunek.jpg, v1691646415/64d3fb4b0a8dd40f8a0b10c3o_yb9znx.jpg, v1691646412/64d3fb4ddb9605406a046125o_xwnste.jpg, v1691646413/64d3fb4cd9de150f760d6f23o_sf6mqc.jpg", false, 28500, new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), "v1691646413/64d3fb431a7e3d0fcf0b80e2o_anphwq.jpg" },
                    { new Guid("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"), new Guid("2a42e928-40ec-4a02-b55e-694c229a6b81"), new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2855), "v1691400757/64c282cfa3ec05e92a0d3c72b_i01jew.jpg, v1691400756/64be408b482fc240c90e4192b_gs1y9y.jpg, v1691400756/64c282d304dc2d7edf0aea22b_daqssd.jpg, v1691400756/64be407d9592e31b710933a2b_ba4eny.jpg, v1691400756/64be4080695c53aef106a703b_k7uurm.jpg", false, 6500, new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), "v1691400757/64c282ca414e1af1a306f532b_yl45gs.jpg" },
                    { new Guid("9597b286-3c2a-4fb5-85be-6625aebd2ec1"), new Guid("a7979b5b-0402-4c36-bd84-6e506464193d"), new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2877), "v1691694986/646d1ee92e0f90965c007009b_kjjfj0.jpg, v1691694986/646d1edae9827c54ff0ed554b_u9c2er.jpg, v1691694985/646d1edb304e77ceed0a5383b_d1umuk.jpg, v1691694985/646d1edd2e0f90965c007007b_k2ilqv.jpg, v1691694985/646d1ee82e0f90965c007008b_eacs1y.jpg, v1691694985/646d1ee2bfecf229390efce3b_pzk4dj.jpg, v1691694986/646d1ee52f544fc2bf0c7032b_ile2it.jpg, v1691694985/646d1ee6304e77ceed0a5384b_dcjzz1.jpg", false, 12000, new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), "v1691694986/646d1ed7b8b79391c90f5463o_ku4zgx.jpg" },
                    { new Guid("96b41a60-8da3-4a54-8422-5c570ae86705"), new Guid("35b8a5f3-59bd-4997-8b33-2c3b8381085f"), new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2870), "v1691647264/64d3f88754cff649d00f9462o_aefttq.jpg, v1691647264/64d3f88a9b30846fd708b337b_ptog3c.jpg, v1691647264/64d3f88d83abf0e673094a92b_uyfdtb.jpg, v1691647264/64d3f891f6111264730a6732b_u8wh49.jpg, v1691647264/64d3f894ad32aa131c03f293b_cxujvp.jpg, v1691647265/64d3f8a4e43d2c67140a7f12b_vzxxhz.jpg", false, 5100, new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), "v1691647266/64d3f8349b30846fd708b336o_fe1ma7.jpg" },
                    { new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"), new Guid("864237e2-7f7a-469f-b019-697c848fc3aa"), new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2730), "v1690614481/64c3abbb2084b666c60eefc3o_gbppag.jpg, v1690614513/64c3abc10593558f030c7612o_b1ppoc.jpg, v1690614511/64c3abc0b533ff0b86051712o_y0v9mv.jpg, v1690614515/64c3abc50593558f030c7613o_ihll6b.jpg", false, 7000, new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), "v1690614468/64c3aba02084b666c60eefc2o_cjrfs0.jpg" },
                    { new Guid("efe9de80-c4b1-478a-8b4e-9320bde47eb5"), new Guid("61b85678-863c-48d6-9809-f426b78e6bfb"), new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2849), "v1691400035/IMG_20230807_120742_550_qamzu3.jpg, v1691400038/IMG_20230807_120609_415_mozoxj.jpg, v1691400035/IMG_20230807_120625_938_nhev8z.jpg, v1691400035/IMG_20230807_120630_549_nuuzsu.jpg, v1691400035/IMG_20230807_120642_795_mny0df.jpg", false, 20500, new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), "v1691400038/IMG_20230807_120600_154_v7y62d.jpg" }
                });

            migrationBuilder.InsertData(
                table: "SaleCars",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "ColorId", "Description", "EngineId", "EuroStandart", "ManufacturerId", "ModelId", "Odometer", "SalePostId", "TechnicalSpecificationURL", "TransmissionType", "VinNumber", "Year" },
                values: new object[,]
                {
                    { new Guid("2a42e928-40ec-4a02-b55e-694c229a6b81"), null, 7, 10, "Import from Switzerland. 4x4 with real 201000 km with catalytic converter. Works excellent.", 5, 4, 28, 350, 202000, new Guid("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"), "https://www.auto-data.net/bg/skoda-octavia-ii-combi-2.0-fsi-150hp-4x4-14228", "Manual", null, 2007 },
                    { new Guid("35b8a5f3-59bd-4997-8b33-2c3b8381085f"), null, 3, 1, "For sale is a car in excellent condition. I am the second owner. Imported from Italy 9 years ago. Always serviced on time and kept in a garage. It is not ridden in winter. No rust or rot. In the car, every system works without exception. A radio with a rear view camera for parking is integrated. Original alloy wheels for the model with good summer tires. There is also a set of winter tires on separate steel rims, which I never drove. Paid civil and examination. The car is fitted with gas injection and runs perfectly on both petrol and gas. With its three original keys - two black and one red service key. The original alarm system is working.", 7, 3, 4, 64, 148000, new Guid("96b41a60-8da3-4a54-8422-5c570ae86705"), null, "Manual", null, 1997 },
                    { new Guid("61b85678-863c-48d6-9809-f426b78e6bfb"), null, 7, 4, "This is my Audi A4 2008 wagon s-line trim", 4, 5, 1, 6, 160000, new Guid("efe9de80-c4b1-478a-8b4e-9320bde47eb5"), "https://www.auto-data.net/bg/audi-a4-avant-b8-8k-3.0-tdi-v6-240hp-quattro-4344", "Automatic", null, 2008 },
                    { new Guid("74483b38-f9ab-4deb-a155-2b04e9cfa647"), null, 7, 1, "Personal hybrid vehichle for sale.", 6, 6, 12, 166, 206600, new Guid("2a84f9fc-7068-42a9-9dac-e49d33284196"), null, "Automatic", null, 2017 },
                    { new Guid("83f3d02f-e083-467f-a105-dc25ac02e3fa"), null, 3, 3, null, 1, 5, 5, 88, 164000, new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"), "https://www.auto-data.net/en/hyundai-ix35-1.7-crdi-115hp-18181", "Manual", null, 2013 },
                    { new Guid("864237e2-7f7a-469f-b019-697c848fc3aa"), null, 2, 2, null, 3, 4, 1, 5, 209000, new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"), "https://www.auto-data.net/en/audi-a3-sportback-8pa-facelift-2008-1.9-tdi-105hp-dpf-4215", "Manual", null, 2009 },
                    { new Guid("a7979b5b-0402-4c36-bd84-6e506464193d"), null, 2, 1, "In a good shape.", 8, 5, 34, 403, 195000, new Guid("9597b286-3c2a-4fb5-85be-6625aebd2ec1"), null, "Manual", null, 2010 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "RentPosts",
                keyColumn: "Id",
                keyValue: new Guid("7475c229-d57d-48b5-a617-911727f9fbc7"));

            migrationBuilder.DeleteData(
                table: "SaleCars",
                keyColumn: "Id",
                keyValue: new Guid("2a42e928-40ec-4a02-b55e-694c229a6b81"));

            migrationBuilder.DeleteData(
                table: "SaleCars",
                keyColumn: "Id",
                keyValue: new Guid("35b8a5f3-59bd-4997-8b33-2c3b8381085f"));

            migrationBuilder.DeleteData(
                table: "SaleCars",
                keyColumn: "Id",
                keyValue: new Guid("61b85678-863c-48d6-9809-f426b78e6bfb"));

            migrationBuilder.DeleteData(
                table: "SaleCars",
                keyColumn: "Id",
                keyValue: new Guid("74483b38-f9ab-4deb-a155-2b04e9cfa647"));

            migrationBuilder.DeleteData(
                table: "SaleCars",
                keyColumn: "Id",
                keyValue: new Guid("83f3d02f-e083-467f-a105-dc25ac02e3fa"));

            migrationBuilder.DeleteData(
                table: "SaleCars",
                keyColumn: "Id",
                keyValue: new Guid("864237e2-7f7a-469f-b019-697c848fc3aa"));

            migrationBuilder.DeleteData(
                table: "SaleCars",
                keyColumn: "Id",
                keyValue: new Guid("a7979b5b-0402-4c36-bd84-6e506464193d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lenders",
                keyColumn: "Id",
                keyValue: new Guid("a614c1dc-5f00-4549-82b3-2bc39de56c8f"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: new Guid("5ac9b2bb-a45f-45b6-be4c-47dd5c44a954"));

            migrationBuilder.DeleteData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"));

            migrationBuilder.DeleteData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("2a84f9fc-7068-42a9-9dac-e49d33284196"));

            migrationBuilder.DeleteData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"));

            migrationBuilder.DeleteData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9597b286-3c2a-4fb5-85be-6625aebd2ec1"));

            migrationBuilder.DeleteData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("96b41a60-8da3-4a54-8422-5c570ae86705"));

            migrationBuilder.DeleteData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"));

            migrationBuilder.DeleteData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("efe9de80-c4b1-478a-8b4e-9320bde47eb5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
