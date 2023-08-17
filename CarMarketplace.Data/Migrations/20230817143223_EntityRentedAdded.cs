using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Data.Migrations
{
    public partial class EntityRentedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => new { x.PostId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_Rents_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_RentPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "RentPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Rents_ClientId",
                table: "Rents",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.UpdateData(
                table: "RentPosts",
                keyColumn: "Id",
                keyValue: new Guid("7475c229-d57d-48b5-a617-911727f9fbc7"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2841));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("2a84f9fc-7068-42a9-9dac-e49d33284196"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("9597b286-3c2a-4fb5-85be-6625aebd2ec1"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("96b41a60-8da3-4a54-8422-5c570ae86705"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2730));

            migrationBuilder.UpdateData(
                table: "SalePosts",
                keyColumn: "Id",
                keyValue: new Guid("efe9de80-c4b1-478a-8b4e-9320bde47eb5"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 14, 18, 11, 37, 651, DateTimeKind.Local).AddTicks(2849));
        }
    }
}
