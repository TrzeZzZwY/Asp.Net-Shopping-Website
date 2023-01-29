using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class Example_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af0ca718-e976-4c3e-92ad-5109576e996b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fac30df4-d21a-408b-9071-ae8974791592");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("58a8e004-3767-4041-9c17-b7d6167f21c6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("7e63ceb5-7983-4264-a54f-0c05185d7ac9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c3b9a9a3-9083-4267-8022-de0c383b1043"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fbb7f9c-6225-4b1f-9ad4-06cda3bf089a", "890c5817-5b2c-4290-ae8b-ca2c83717a54", "User", "USER" },
                    { "90c4620a-8d8f-4518-81f3-f051d5c83383", "08886fa1-0e73-425f-9b11-5f1846c72601", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("10f70f27-6034-45b1-891a-8df78e94c456"), "Czapka" },
                    { new Guid("21ee6f00-bb51-466f-bc63-8be6c5506852"), "Pluszak" },
                    { new Guid("f3591a5a-f3cb-41d3-9037-4b306b78fde7"), "Szalik" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemAvalibility", "ItemDescription", "ItemDiscount", "ItemImageName", "ItemName", "ItemPrice" },
                values: new object[,]
                {
                    { new Guid("3b5007ab-8fce-487d-b2f9-a1802704c568"), 0, "Bardzo ciepła ręcznie wykonana czapka", 0, null, "Szara czapka", 70m },
                    { new Guid("559cb5d9-9e70-4751-97bd-2595cac604ff"), 2, "Duży pluszowy ręcznie wykonany miś", 0, null, "Pluszowy miś", 70m },
                    { new Guid("690f3109-0d9d-4d41-b227-02ecc1123aa0"), 10, "Bardzo ciepły ręcznie wykonany szalik", 30, null, "Czarny szalik", 120m },
                    { new Guid("6d93bb03-6636-4530-a978-f7da85164bfb"), 3, "Zielona szydełkowa żaba, wykonana ręcznie z mięciutkiej włóczki", 10, null, "Szydełkowa Żaba", 100m },
                    { new Guid("83b59d0a-cd7a-4f6e-83ab-73de3ee0e596"), 0, "Bardzo ciepły ręcznie wykonany szalik", 0, null, "Granatowy Szalik", 100m },
                    { new Guid("e87e3099-f4ce-4f5e-80a7-8f2719904ed2"), 1, "Bardzo ciepła ręcznie wykonana czapka", 0, null, "Biała czapka", 110m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fbb7f9c-6225-4b1f-9ad4-06cda3bf089a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90c4620a-8d8f-4518-81f3-f051d5c83383");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("10f70f27-6034-45b1-891a-8df78e94c456"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("21ee6f00-bb51-466f-bc63-8be6c5506852"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("f3591a5a-f3cb-41d3-9037-4b306b78fde7"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("3b5007ab-8fce-487d-b2f9-a1802704c568"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("559cb5d9-9e70-4751-97bd-2595cac604ff"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("690f3109-0d9d-4d41-b227-02ecc1123aa0"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("6d93bb03-6636-4530-a978-f7da85164bfb"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("83b59d0a-cd7a-4f6e-83ab-73de3ee0e596"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("e87e3099-f4ce-4f5e-80a7-8f2719904ed2"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "af0ca718-e976-4c3e-92ad-5109576e996b", "9eecf99f-6ad0-413f-881e-1a4d92ef83f1", "User", "USER" },
                    { "fac30df4-d21a-408b-9071-ae8974791592", "20c815d5-14a4-4315-8688-6720c8eee23c", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("58a8e004-3767-4041-9c17-b7d6167f21c6"), "Pluszak" },
                    { new Guid("7e63ceb5-7983-4264-a54f-0c05185d7ac9"), "Czapka" },
                    { new Guid("c3b9a9a3-9083-4267-8022-de0c383b1043"), "Szalik" }
                });
        }
    }
}
