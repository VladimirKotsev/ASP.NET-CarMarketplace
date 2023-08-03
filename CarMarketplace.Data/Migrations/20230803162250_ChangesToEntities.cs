using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class ChangesToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Displacement",
                table: "Engines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 34, "Alfa Romeo" },
                    { 35, "Lancia" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerName", "ModelName" },
                values: new object[,]
                {
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
                    { 427, "Lancia", "Thema" }
                });

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 3, 19, 22, 49, 885, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 3, 19, 22, 49, 885, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 3, 19, 22, 49, 885, DateTimeKind.Local).AddTicks(2374));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 35);

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
                keyValue: 403);

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

            migrationBuilder.DropColumn(
                name: "City",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "Displacement",
                table: "Engines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "PublishDate",
                value: new DateTime(2023, 7, 30, 11, 20, 22, 80, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"),
                column: "PublishDate",
                value: new DateTime(2023, 7, 30, 11, 20, 22, 80, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "PublishDate",
                value: new DateTime(2023, 7, 30, 11, 20, 22, 80, DateTimeKind.Local).AddTicks(9377));
        }
    }
}
