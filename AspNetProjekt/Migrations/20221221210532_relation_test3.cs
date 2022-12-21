using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class relation_test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("61dd9ecb-a782-4f72-af96-8d1893d47df8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("6aaa00d1-47cb-4463-b6c1-4358bcd64600"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("78af5651-b919-4914-a009-e74a72dc73b9"));

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

            migrationBuilder.CreateIndex(
                name: "IX_UsersWishLists_ItemId",
                table: "UsersWishLists",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersWishLists_Items_ItemId",
                table: "UsersWishLists",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersWishLists_Items_ItemId",
                table: "UsersWishLists");

            migrationBuilder.DropIndex(
                name: "IX_UsersWishLists_ItemId",
                table: "UsersWishLists");

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

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: new Guid("61dd9ecb-a782-4f72-af96-8d1893d47df8"));

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: new Guid("6aaa00d1-47cb-4463-b6c1-4358bcd64600"));

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: new Guid("78af5651-b919-4914-a009-e74a72dc73b9"));
        }
    }
}
