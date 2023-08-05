using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class ChangesOdometerDataTypeForCarEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Odometer",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("83f3d02f-e083-467f-a105-dc25ac02e3fa"),
                column: "Odometer",
                value: 164000);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("864237e2-7f7a-469f-b019-697c848fc3aa"),
                column: "Odometer",
                value: 209000);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("913c5349-94de-4dc2-9e7d-346b57648227"),
                column: "Odometer",
                value: 219000);

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                columns: new[] { "Price", "PublishDate" },
                values: new object[] { 8500, new DateTime(2023, 8, 5, 13, 42, 7, 631, DateTimeKind.Local).AddTicks(4895) });

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"),
                columns: new[] { "Price", "PublishDate" },
                values: new object[] { 1000, new DateTime(2023, 8, 5, 13, 42, 7, 631, DateTimeKind.Local).AddTicks(4888) });

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                columns: new[] { "Price", "PublishDate" },
                values: new object[] { 3500, new DateTime(2023, 8, 5, 13, 42, 7, 631, DateTimeKind.Local).AddTicks(4831) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Odometer",
                table: "Cars",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("83f3d02f-e083-467f-a105-dc25ac02e3fa"),
                column: "Odometer",
                value: "164 000");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("864237e2-7f7a-469f-b019-697c848fc3aa"),
                column: "Odometer",
                value: "209 000");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("913c5349-94de-4dc2-9e7d-346b57648227"),
                column: "Odometer",
                value: "219 000");

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                columns: new[] { "Price", "PublishDate" },
                values: new object[] { 17000, new DateTime(2023, 8, 3, 19, 40, 43, 309, DateTimeKind.Local).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"),
                columns: new[] { "Price", "PublishDate" },
                values: new object[] { 2000, new DateTime(2023, 8, 3, 19, 40, 43, 309, DateTimeKind.Local).AddTicks(661) });

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                columns: new[] { "Price", "PublishDate" },
                values: new object[] { 7000, new DateTime(2023, 8, 3, 19, 40, 43, 309, DateTimeKind.Local).AddTicks(598) });
        }
    }
}
