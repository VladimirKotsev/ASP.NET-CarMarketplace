using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class EntityDateTimeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedToFavourites",
                table: "SalePostApplicationUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 9, 16, 8, 46, 442, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 9, 16, 8, 46, 442, DateTimeKind.Local).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 9, 16, 8, 46, 442, DateTimeKind.Local).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 9, 16, 8, 46, 442, DateTimeKind.Local).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("efe9de80-c4b1-478a-8b4e-9320bde47eb5"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 9, 16, 8, 46, 442, DateTimeKind.Local).AddTicks(4269));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedToFavourites",
                table: "SalePostApplicationUsers");

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 9, 9, 41, 7, 693, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 9, 9, 41, 7, 693, DateTimeKind.Local).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 9, 9, 41, 7, 693, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 9, 9, 41, 7, 693, DateTimeKind.Local).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("efe9de80-c4b1-478a-8b4e-9320bde47eb5"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 9, 9, 41, 7, 693, DateTimeKind.Local).AddTicks(7298));
        }
    }
}
