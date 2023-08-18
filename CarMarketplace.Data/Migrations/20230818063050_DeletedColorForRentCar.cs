using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class DeletedColorForRentCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentCars_Colors_ColorId",
                table: "RentCars");

            migrationBuilder.DropIndex(
                name: "IX_RentCars_ColorId",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "RentCars");

            migrationBuilder.UpdateData(
                table: "RentPosts",
                keyColumn: "Id",
                keyValue: new Guid("7475c229-d57d-48b5-a617-911727f9fbc7"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 18, 6, 30, 49, 996, DateTimeKind.Utc).AddTicks(5513));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 18, 9, 30, 50, 34, DateTimeKind.Local).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("2a84f9fc-7068-42a9-9dac-e49d33284196"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 18, 9, 30, 50, 34, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 18, 9, 30, 50, 34, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9597b286-3c2a-4fb5-85be-6625aebd2ec1"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 18, 9, 30, 50, 34, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("96b41a60-8da3-4a54-8422-5c570ae86705"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 18, 9, 30, 50, 34, DateTimeKind.Local).AddTicks(8271));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 18, 9, 30, 50, 34, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("efe9de80-c4b1-478a-8b4e-9320bde47eb5"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 18, 9, 30, 50, 34, DateTimeKind.Local).AddTicks(8243));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "RentCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: new Guid("5ac9b2bb-a45f-45b6-be4c-47dd5c44a954"),
                column: "ColorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "RentPosts",
                keyColumn: "Id",
                keyValue: new Guid("7475c229-d57d-48b5-a617-911727f9fbc7"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 17, 14, 32, 22, 441, DateTimeKind.Utc).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 17, 17, 32, 22, 443, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("2a84f9fc-7068-42a9-9dac-e49d33284196"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 17, 17, 32, 22, 443, DateTimeKind.Local).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 17, 17, 32, 22, 443, DateTimeKind.Local).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9597b286-3c2a-4fb5-85be-6625aebd2ec1"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 17, 17, 32, 22, 443, DateTimeKind.Local).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("96b41a60-8da3-4a54-8422-5c570ae86705"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 17, 17, 32, 22, 443, DateTimeKind.Local).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 17, 17, 32, 22, 443, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("efe9de80-c4b1-478a-8b4e-9320bde47eb5"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 17, 17, 32, 22, 443, DateTimeKind.Local).AddTicks(9744));

            migrationBuilder.CreateIndex(
                name: "IX_RentCars_ColorId",
                table: "RentCars",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentCars_Colors_ColorId",
                table: "RentCars",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
