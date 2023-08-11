using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class AddedDbSetForCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Provinces_ProvinceId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_City_CityId",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_City_ProvinceId",
                table: "Cities",
                newName: "IX_Cities_ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 18, 5, 3, 285, DateTimeKind.Local).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("2a84f9fc-7068-42a9-9dac-e49d33284196"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 18, 5, 3, 285, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 18, 5, 3, 285, DateTimeKind.Local).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9597b286-3c2a-4fb5-85be-6625aebd2ec1"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 18, 5, 3, 285, DateTimeKind.Local).AddTicks(5322));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("96b41a60-8da3-4a54-8422-5c570ae86705"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 18, 5, 3, 285, DateTimeKind.Local).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 18, 5, 3, 285, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("efe9de80-c4b1-478a-8b4e-9320bde47eb5"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 18, 5, 3, 285, DateTimeKind.Local).AddTicks(5285));

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Cities_CityId",
                table: "Sellers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Cities_CityId",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_ProvinceId",
                table: "City",
                newName: "IX_City_ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 23, 36, 16, 878, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("2a84f9fc-7068-42a9-9dac-e49d33284196"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 23, 36, 16, 878, DateTimeKind.Local).AddTicks(1295));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 23, 36, 16, 878, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9597b286-3c2a-4fb5-85be-6625aebd2ec1"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 23, 36, 16, 878, DateTimeKind.Local).AddTicks(1314));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("96b41a60-8da3-4a54-8422-5c570ae86705"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 23, 36, 16, 878, DateTimeKind.Local).AddTicks(1307));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 23, 36, 16, 878, DateTimeKind.Local).AddTicks(1207));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("efe9de80-c4b1-478a-8b4e-9320bde47eb5"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 23, 36, 16, 878, DateTimeKind.Local).AddTicks(1269));

            migrationBuilder.AddForeignKey(
                name: "FK_City_Provinces_ProvinceId",
                table: "City",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_City_CityId",
                table: "Sellers",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
