using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class change_names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerShoppingCartItem_UsersShoppingCarts_CustomerShoppingCartsCustomerId",
                table: "CustomerShoppingCartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersShoppingCarts_Customers_CustomerId",
                table: "UsersShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersWishLists_Customers_CustomerId",
                table: "UsersWishLists");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersWishLists_Items_ItemId",
                table: "UsersWishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersWishLists",
                table: "UsersWishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersShoppingCarts",
                table: "UsersShoppingCarts");

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

            migrationBuilder.RenameTable(
                name: "UsersWishLists",
                newName: "CustomersWishLists");

            migrationBuilder.RenameTable(
                name: "UsersShoppingCarts",
                newName: "CustomersShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_UsersWishLists_ItemId",
                table: "CustomersWishLists",
                newName: "IX_CustomersWishLists_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersWishLists_CustomerId",
                table: "CustomersWishLists",
                newName: "IX_CustomersWishLists_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomersWishLists",
                table: "CustomersWishLists",
                columns: new[] { "CustomerId", "ItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomersShoppingCarts",
                table: "CustomersShoppingCarts",
                column: "CustomerId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5379b186-ba02-4999-9314-6cef260b51ae", "a0cb8c63-accc-438d-ac89-92ad3dbe8d47", "Admin", "ADMIN" },
                    { "f843ebee-2cd2-4074-a255-e241f68cbfc7", "2170b0c1-8208-4e20-8cc7-a41282436a11", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("220df152-cd43-48df-9ff4-3d3ba75766a3"), "Pluszak" },
                    { new Guid("8dddac48-7bc7-404e-a8f5-f072070ba704"), "Szalik" },
                    { new Guid("ff8ac4a4-e92f-438c-a404-e28696958fee"), "Czapka" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerShoppingCartItem_CustomersShoppingCarts_CustomerShoppingCartsCustomerId",
                table: "CustomerShoppingCartItem",
                column: "CustomerShoppingCartsCustomerId",
                principalTable: "CustomersShoppingCarts",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersShoppingCarts_Customers_CustomerId",
                table: "CustomersShoppingCarts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersWishLists_Customers_CustomerId",
                table: "CustomersWishLists",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersWishLists_Items_ItemId",
                table: "CustomersWishLists",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerShoppingCartItem_CustomersShoppingCarts_CustomerShoppingCartsCustomerId",
                table: "CustomerShoppingCartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersShoppingCarts_Customers_CustomerId",
                table: "CustomersShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersWishLists_Customers_CustomerId",
                table: "CustomersWishLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersWishLists_Items_ItemId",
                table: "CustomersWishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomersWishLists",
                table: "CustomersWishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomersShoppingCarts",
                table: "CustomersShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5379b186-ba02-4999-9314-6cef260b51ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f843ebee-2cd2-4074-a255-e241f68cbfc7");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("220df152-cd43-48df-9ff4-3d3ba75766a3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("8dddac48-7bc7-404e-a8f5-f072070ba704"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("ff8ac4a4-e92f-438c-a404-e28696958fee"));

            migrationBuilder.RenameTable(
                name: "CustomersWishLists",
                newName: "UsersWishLists");

            migrationBuilder.RenameTable(
                name: "CustomersShoppingCarts",
                newName: "UsersShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_CustomersWishLists_ItemId",
                table: "UsersWishLists",
                newName: "IX_UsersWishLists_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomersWishLists_CustomerId",
                table: "UsersWishLists",
                newName: "IX_UsersWishLists_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersWishLists",
                table: "UsersWishLists",
                columns: new[] { "CustomerId", "ItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersShoppingCarts",
                table: "UsersShoppingCarts",
                column: "CustomerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerShoppingCartItem_UsersShoppingCarts_CustomerShoppingCartsCustomerId",
                table: "CustomerShoppingCartItem",
                column: "CustomerShoppingCartsCustomerId",
                principalTable: "UsersShoppingCarts",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersShoppingCarts_Customers_CustomerId",
                table: "UsersShoppingCarts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersWishLists_Customers_CustomerId",
                table: "UsersWishLists",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersWishLists_Items_ItemId",
                table: "UsersWishLists",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
