using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("245f5db9-7645-4376-a815-abb26b3849c5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("e53394f9-2c05-440a-b148-4da84ec7603a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("f0f51ae5-bca8-4293-bdd8-5836270e3532"));

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("1e89d7a8-26b8-4531-947c-96f71f432fc1"), "Czapka" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("542ea9d9-29bc-4895-89e8-0acf806f6827"), "Pluszak" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("6d6f9b3e-f2c8-4ec8-b2fc-37c6623d06ac"), "Szalik" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("1e89d7a8-26b8-4531-947c-96f71f432fc1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("542ea9d9-29bc-4895-89e8-0acf806f6827"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("6d6f9b3e-f2c8-4ec8-b2fc-37c6623d06ac"));

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: new Guid("245f5db9-7645-4376-a815-abb26b3849c5"));

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: new Guid("e53394f9-2c05-440a-b148-4da84ec7603a"));

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: new Guid("f0f51ae5-bca8-4293-bdd8-5836270e3532"));
        }
    }
}
