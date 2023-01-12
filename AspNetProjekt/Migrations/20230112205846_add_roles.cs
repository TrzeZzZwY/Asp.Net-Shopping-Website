using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class add_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("2e4e8cb8-782b-47fb-94d5-79d4504e6d0f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("79f39c4b-7f31-47a6-b783-dacc7e76c9f1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("95e6c475-930e-46c1-81f9-984000f3a422"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "75d5c5fc-38fa-414e-a754-e30e8177e9bd", "d98a4ad5-6c9b-41ff-a836-de15ccb4ad5d", "Admin", "ADMIN" },
                    { "ac6d6444-7867-4459-a2d4-22d00128db52", "7c86e724-5775-4ae9-bd1c-3d876ffe3c98", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("476410a0-4695-40b9-8955-48b729341fa0"), "Czapka" },
                    { new Guid("6b798f2b-71a4-4c51-bca6-43a0ecd01d63"), "Pluszak" },
                    { new Guid("7c0429ba-c860-45a3-9f29-f120560ebe66"), "Szalik" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75d5c5fc-38fa-414e-a754-e30e8177e9bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac6d6444-7867-4459-a2d4-22d00128db52");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("476410a0-4695-40b9-8955-48b729341fa0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("6b798f2b-71a4-4c51-bca6-43a0ecd01d63"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("7c0429ba-c860-45a3-9f29-f120560ebe66"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("2e4e8cb8-782b-47fb-94d5-79d4504e6d0f"), "Szalik" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("79f39c4b-7f31-47a6-b783-dacc7e76c9f1"), "Czapka" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("95e6c475-930e-46c1-81f9-984000f3a422"), "Pluszak" });
        }
    }
}
