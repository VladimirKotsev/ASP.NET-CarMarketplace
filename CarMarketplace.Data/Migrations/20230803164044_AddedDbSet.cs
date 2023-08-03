using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class AddedDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Province_ProvinceId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Province",
                table: "Province");

            migrationBuilder.RenameTable(
                name: "Province",
                newName: "Provinces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 3, 19, 40, 43, 309, DateTimeKind.Local).AddTicks(672));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 3, 19, 40, 43, 309, DateTimeKind.Local).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "PublishDate",
                value: new DateTime(2023, 8, 3, 19, 40, 43, 309, DateTimeKind.Local).AddTicks(598));

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Provinces_ProvinceId",
                table: "Cars",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Provinces_ProvinceId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces");

            migrationBuilder.RenameTable(
                name: "Provinces",
                newName: "Province");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Province",
                table: "Province",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Province_ProvinceId",
                table: "Cars",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
