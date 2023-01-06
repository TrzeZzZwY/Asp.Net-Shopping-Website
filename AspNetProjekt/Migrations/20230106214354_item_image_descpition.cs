using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class item_image_descpition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("26a2e4cc-44d6-4309-906e-e8139e03bd4f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("463fa8e1-d023-4434-910c-e3984c111cf6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c9a23282-9993-438c-bb82-32d5d27c4a0a"));

            migrationBuilder.RenameColumn(
                name: "ItemDiscout",
                table: "Items",
                newName: "ItemDiscount");

            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemImageName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("94a3e372-ee69-46ce-9e4f-233e6049551d"), "Pluszak" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("a400d90f-c408-4b63-a6ff-e13626387f63"), "Szalik" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("e19ba9c5-0180-43a4-892c-7bbbc14e885f"), "Czapka" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("94a3e372-ee69-46ce-9e4f-233e6049551d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("a400d90f-c408-4b63-a6ff-e13626387f63"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("e19ba9c5-0180-43a4-892c-7bbbc14e885f"));

            migrationBuilder.DropColumn(
                name: "ItemDescription",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemImageName",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemDiscount",
                table: "Items",
                newName: "ItemDiscout");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("26a2e4cc-44d6-4309-906e-e8139e03bd4f"), "Pluszak" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("463fa8e1-d023-4434-910c-e3984c111cf6"), "Szalik" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("c9a23282-9993-438c-bb82-32d5d27c4a0a"), "Czapka" });
        }
    }
}
