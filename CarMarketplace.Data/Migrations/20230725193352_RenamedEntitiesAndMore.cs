using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class RenamedEntitiesAndMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Seller_SellerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Seller_AspNetUsers_UserId",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "Sellers");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_UserId",
                table: "Sellers",
                newName: "IX_Sellers_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "LenderId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLender",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSeller",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Lenders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lenders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PricePerDay = table.Column<int>(type: "int", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentPosts_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalePosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalePosts_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalePosts_Sellers_UserId",
                        column: x => x.UserId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 19, "Cream" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
                    { 45, "Mercedes-Benz", "A" },
                    { 46, "Mercedes-Benz", "B" },
                    { 47, "Mercedes-Benz", "C" },
                    { 48, "Mercedes-Benz", "CL" },
                    { 49, "Mercedes-Benz", "CLA" },
                    { 50, "Mercedes-Benz", "CLS" },
                    { 51, "Mercedes-Benz", "CLK" },
                    { 52, "Mercedes-Benz", "E" },
                    { 53, "Mercedes-Benz", "G" },
                    { 54, "Mercedes-Benz", "GLA" },
                    { 55, "Mercedes-Benz", "GLB" },
                    { 56, "Mercedes-Benz", "GLC" },
                    { 57, "Mercedes-Benz", "GLE" },
                    { 58, "Mercedes-Benz", "GLS" },
                    { 59, "Mercedes-Benz", "S" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
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
                    { 95, "Ford", "C-MAX" },
                    { 96, "Ford", "Escort" },
                    { 97, "Nissan", "Micra" },
                    { 98, "Nissan", "Juke" },
                    { 99, "Nissan", "Qashqai" },
                    { 100, "Nissan", "X-Trail" },
                    { 101, "Nissan", "Leaf" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
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
                    { 137, "Peugeot", "4007" },
                    { 138, "Peugeot", "4008" },
                    { 139, "Peugeot", "406" },
                    { 140, "Peugeot", "407" },
                    { 141, "Peugeot", "408" },
                    { 142, "Peugeot", "5008" },
                    { 143, "Peugeot", "508" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
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
                    { 179, "Toyota", "Celica" },
                    { 180, "Chevrolet", "Spark" },
                    { 181, "Chevrolet", "Aveo" },
                    { 182, "Chevrolet", "Cruze" },
                    { 183, "Chevrolet", "Trax" },
                    { 184, "Chevrolet", "Captiva" },
                    { 185, "Chevrolet", "Orlando" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
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
                    { 221, "Kia", "Venga" },
                    { 222, "Lexus", "IS" },
                    { 223, "Lexus", "ES" },
                    { 224, "Lexus", "GS" },
                    { 225, "Lexus", "LS" },
                    { 226, "Lexus", "RX" },
                    { 227, "Lexus", "NX" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
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
                    { 250, "Subaru", "Ascent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_LenderId",
                table: "Cars",
                column: "LenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Lenders_UserId",
                table: "Lenders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RentPosts_CarId",
                table: "RentPosts",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentPosts_UserId",
                table: "RentPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePosts_CarId",
                table: "SalePosts",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePosts_UserId",
                table: "SalePosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Lenders_LenderId",
                table: "Cars",
                column: "LenderId",
                principalTable: "Lenders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Sellers_SellerId",
                table: "Cars",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_AspNetUsers_UserId",
                table: "Sellers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Lenders_LenderId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Sellers_SellerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_AspNetUsers_UserId",
                table: "Sellers");

            migrationBuilder.DropTable(
                name: "Lenders");

            migrationBuilder.DropTable(
                name: "RentPosts");

            migrationBuilder.DropTable(
                name: "SalePosts");

            migrationBuilder.DropIndex(
                name: "IX_Cars_LenderId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

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
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

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
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4);

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
                keyValue: 10);

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
                keyValue: 64);

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
                keyValue: 88);

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
                keyValue: 116);

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
                keyValue: 166);

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

            migrationBuilder.DropColumn(
                name: "LenderId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsLender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsSeller",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Seller");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_UserId",
                table: "Seller",
                newName: "IX_Seller_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Seller_SellerId",
                table: "Cars",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_AspNetUsers_UserId",
                table: "Seller",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
