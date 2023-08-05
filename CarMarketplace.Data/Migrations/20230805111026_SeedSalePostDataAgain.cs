using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class SeedSalePostDataAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 5, 14, 10, 25, 413, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 5, 14, 10, 25, 413, DateTimeKind.Local).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 5, 14, 10, 25, 413, DateTimeKind.Local).AddTicks(5092));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 5, 13, 42, 7, 631, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 5, 13, 42, 7, 631, DateTimeKind.Local).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 5, 13, 42, 7, 631, DateTimeKind.Local).AddTicks(4831));
        }
    }
}
