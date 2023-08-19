using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class EditedEntityRented : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Rents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Rents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Rents",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickUpDate",
                table: "Rents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Rents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RentPosts",
                keyColumn: "Id",
                keyValue: new Guid("7475c229-d57d-48b5-a617-911727f9fbc7"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 19, 8, 0, 51, 595, DateTimeKind.Utc).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 19, 11, 0, 51, 598, DateTimeKind.Local).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("2a84f9fc-7068-42a9-9dac-e49d33284196"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 19, 11, 0, 51, 598, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 19, 11, 0, 51, 598, DateTimeKind.Local).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9597b286-3c2a-4fb5-85be-6625aebd2ec1"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 19, 11, 0, 51, 598, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("96b41a60-8da3-4a54-8422-5c570ae86705"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 19, 11, 0, 51, 598, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 19, 11, 0, 51, 598, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("efe9de80-c4b1-478a-8b4e-9320bde47eb5"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 19, 11, 0, 51, 598, DateTimeKind.Local).AddTicks(2160));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "PickUpDate",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Rents");

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
    }
}
