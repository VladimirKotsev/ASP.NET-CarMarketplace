using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class SeedingCarsForSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalePosts_Sellers_UserId",
                table: "SalePosts");

            migrationBuilder.DropColumn(
                name: "CoolantCapacity",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "OilCapacity",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SalePosts",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_SalePosts_UserId",
                table: "SalePosts",
                newName: "IX_SalePosts_SellerId");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrls",
                table: "SalePosts",
                type: "varchar(5000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 20, "Silver" });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "Displacement", "FuelType", "Horsepower" },
                values: new object[,]
                {
                    { 1, 1900, "Diesel", 130 },
                    { 2, 1900, "Diesel", 105 },
                    { 3, 2000, "Diesel", 140 },
                    { 4, 1600, "Diesel", 130 },
                    { 5, 2000, "Diesel", 140 },
                    { 6, 2100, "Diesel", 136 },
                    { 7, 2000, "Diesel", 136 },
                    { 8, 1500, "Diesel", 101 },
                    { 9, 1600, "Diesel", 118 },
                    { 10, 1600, "Diesel", 130 },
                    { 11, 1700, "Diesel", 116 },
                    { 12, 2000, "Diesel", 190 },
                    { 13, 1600, "Diesel", 160 },
                    { 14, 2000, "Diesel", 150 },
                    { 15, 1600, "Diesel", 136 },
                    { 16, 1500, "Diesel", 115 },
                    { 17, 3000, "Diesel", 330 },
                    { 18, 3000, "Diesel", 400 },
                    { 19, 3000, "Diesel", 235 },
                    { 20, 2000, "Diesel", 240 },
                    { 21, 2000, "Diesel", 235 },
                    { 22, 1000, "Petrol", 115 },
                    { 23, 1000, "Petrol", 140 },
                    { 24, 1200, "Petrol", 130 },
                    { 25, 1200, "Petrol", 130 },
                    { 26, 1200, "Petrol", 80 },
                    { 27, 2000, "Petrol", 220 },
                    { 28, 2000, "Petrol", 300 },
                    { 29, 2000, "Petrol", 245 },
                    { 30, 2000, "Petrol", 255 },
                    { 31, 1400, "Petrol", 150 },
                    { 32, 1400, "Petrol", 170 },
                    { 33, 1200, "Petrol", 116 },
                    { 34, 1500, "Petrol", 150 },
                    { 35, 1300, "Petrol", 140 },
                    { 36, 1500, "Petrol", 130 },
                    { 37, 1600, "Petrol", 177 },
                    { 38, 2000, "Petrol", 228 },
                    { 39, 1800, "Petrol", 237 },
                    { 40, 2500, "Petrol", 186 },
                    { 41, 2000, "Petrol", 152 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "Displacement", "FuelType", "Horsepower" },
                values: new object[] { 42, 1500, "Petrol", 163 });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
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
                    { 263, "Volkswagen", "Scirocco" },
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
                    { 291, "Citroën", "Berlingo" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
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
                    { 305, "Dacia", "Logan Stepway" },
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
                    { 333, "Mini", "Cooper" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
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
                    { 347, "Seat", "Cupra" },
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
                    { 375, "Rolls-Royce", "Phantom" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
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
                    { 389, "Ferrari", "GTC4Lusso" },
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
                    { 400, "Lamborghini", "Reventón" }
                });

            migrationBuilder.InsertData(
                table: "Province",
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
                    { 17, "Silistra" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ProvinceName" },
                values: new object[,]
                {
                    { 18, "Sliven" },
                    { 19, "Smolyan" },
                    { 20, "Sofia-Grad" },
                    { 21, "Sofia" },
                    { 22, "Stara Zagora" },
                    { 23, "Targovishte" },
                    { 24, "Varna" },
                    { 25, "Veliko Tarnovo" },
                    { 26, "Vidin" },
                    { 27, "Vratsa" },
                    { 28, "Yambol" }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), "Vladimir", "Kotsev", "0899904741", new Guid("eaba96e7-8ad5-436d-be68-424370407635") });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "ColorId", "Description", "EngineId", "EuroStandart", "LenderId", "ManufacturerId", "ModelId", "Odometer", "ProvinceId", "SellerId", "TechnicalSpecificationURL", "TransmissionType", "VinNumber", "Year" },
                values: new object[] { new Guid("83f3d02f-e083-467f-a105-dc25ac02e3fa"), null, 3, 3, null, 11, 5, null, 5, 88, "164 000", 13, new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), "https://www.auto-data.net/en/hyundai-ix35-1.7-crdi-115hp-18181", "Manual", null, 2013 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "ColorId", "Description", "EngineId", "EuroStandart", "LenderId", "ManufacturerId", "ModelId", "Odometer", "ProvinceId", "SellerId", "TechnicalSpecificationURL", "TransmissionType", "VinNumber", "Year" },
                values: new object[] { new Guid("864237e2-7f7a-469f-b019-697c848fc3aa"), null, 2, 2, null, 2, 4, null, 1, 5, "209 000", 9, new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), "https://www.auto-data.net/en/audi-a3-sportback-8pa-facelift-2008-1.9-tdi-105hp-dpf-4215", "Manual", null, 2009 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "ColorId", "Description", "EngineId", "EuroStandart", "LenderId", "ManufacturerId", "ModelId", "Odometer", "ProvinceId", "SellerId", "TechnicalSpecificationURL", "TransmissionType", "VinNumber", "Year" },
                values: new object[] { new Guid("913c5349-94de-4dc2-9e7d-346b57648227"), null, 2, 5, null, 26, 3, null, 10, 145, "219 000", 7, new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"), "https://www.auto-data.net/en/fiat-punto-ii-188-3dr-1.2-80hp-6984", "Manual", null, 2000 });

            migrationBuilder.InsertData(
                table: "SalePosts",
                columns: new[] { "Id", "CarId", "ImageUrls", "Price", "PublishDate", "SellerId" },
                values: new object[] { new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"), new Guid("83f3d02f-e083-467f-a105-dc25ac02e3fa"), "v1690705038/64c11d4911a396d9060766d2o_j0myw0.jpg, v1690705040/64c11d4d7f1d92d2780184a3o_wdzk9m.jpg, v1690705038/64c11d507f1d92d2780184a4o_sedhtb.jpg, v1690705038/64c37299fc2825af7307f104o_wbbnrh.jpg, v1690705038/64c11d5e0ccd31ea250803b2o_j83454.jpg", 17000, new DateTime(2023, 7, 30, 11, 20, 22, 80, DateTimeKind.Local).AddTicks(9457), new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16") });

            migrationBuilder.InsertData(
                table: "SalePosts",
                columns: new[] { "Id", "CarId", "ImageUrls", "Price", "PublishDate", "SellerId" },
                values: new object[] { new Guid("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"), new Guid("913c5349-94de-4dc2-9e7d-346b57648227"), "v1690703960/20230701_162102_fuhvrm.jpg, v1690704036/20230219_151259-min_rcyhtb.jpg, v1690703960/20230701_162127_mv4jno.jpg, v1690703960/20230701_162102_fuhvrm.jpg", 2000, new DateTime(2023, 7, 30, 11, 20, 22, 80, DateTimeKind.Local).AddTicks(9448), new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16") });

            migrationBuilder.InsertData(
                table: "SalePosts",
                columns: new[] { "Id", "CarId", "ImageUrls", "Price", "PublishDate", "SellerId" },
                values: new object[] { new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"), new Guid("864237e2-7f7a-469f-b019-697c848fc3aa"), "v1690614468/64c3aba02084b666c60eefc2o_cjrfs0.jpg, v1690614481/64c3abbb2084b666c60eefc3o_gbppag.jpg, v1690614513/64c3abc10593558f030c7612o_b1ppoc.jpg, v1690614511/64c3abc0b533ff0b86051712o_y0v9mv.jpg, v1690614515/64c3abc50593558f030c7613o_ihll6b.jpg", 7000, new DateTime(2023, 7, 30, 11, 20, 22, 80, DateTimeKind.Local).AddTicks(9377), new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16") });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ProvinceId",
                table: "Cars",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Province_ProvinceId",
                table: "Cars",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePosts_Sellers_SellerId",
                table: "SalePosts",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Province_ProvinceId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePosts_Sellers_SellerId",
                table: "SalePosts");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ProvinceId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 20);

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
                table: "Engines",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 42);

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
                keyValue: 350);

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
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"));

            migrationBuilder.DeleteData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"));

            migrationBuilder.DeleteData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("83f3d02f-e083-467f-a105-dc25ac02e3fa"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("864237e2-7f7a-469f-b019-697c848fc3aa"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("913c5349-94de-4dc2-9e7d-346b57648227"));

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: new Guid("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"));

            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "SalePosts");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "SalePosts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SalePosts_SellerId",
                table: "SalePosts",
                newName: "IX_SalePosts_UserId");

            migrationBuilder.AddColumn<double>(
                name: "CoolantCapacity",
                table: "Engines",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OilCapacity",
                table: "Engines",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePosts_Sellers_UserId",
                table: "SalePosts",
                column: "UserId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
