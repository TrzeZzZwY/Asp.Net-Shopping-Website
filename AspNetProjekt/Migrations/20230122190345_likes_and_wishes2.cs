using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class likes_and_wishes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerItem_Customers_ItemLikesCustomerId",
                table: "CustomerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerItem_Items_ItemLikesItemId",
                table: "CustomerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerItem1_Customers_CustomerWishListCustomerId",
                table: "CustomerItem1");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerItem1_Items_CustomerWishListItemId",
                table: "CustomerItem1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerItem1",
                table: "CustomerItem1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerItem",
                table: "CustomerItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2121f5e9-19df-45cc-a43d-737f1cf7bae4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f25d739-730c-4cc1-b514-322e74338ac7");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("201a50b9-2b0d-4d31-9228-bf0a76a278b2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("414d95f5-765b-407e-8c32-bcba94adc248"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("d9f868c2-3d98-4320-8f86-93158c25db1f"));

            migrationBuilder.RenameTable(
                name: "CustomerItem1",
                newName: "Item_Costomer_Wishes");

            migrationBuilder.RenameTable(
                name: "CustomerItem",
                newName: "Item_Customer_Likes");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerItem1_CustomerWishListItemId",
                table: "Item_Costomer_Wishes",
                newName: "IX_Item_Costomer_Wishes_CustomerWishListItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerItem_ItemLikesItemId",
                table: "Item_Customer_Likes",
                newName: "IX_Item_Customer_Likes_ItemLikesItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item_Costomer_Wishes",
                table: "Item_Costomer_Wishes",
                columns: new[] { "CustomerWishListCustomerId", "CustomerWishListItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item_Customer_Likes",
                table: "Item_Customer_Likes",
                columns: new[] { "ItemLikesCustomerId", "ItemLikesItemId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Costomer_Wishes_Customers_CustomerWishListCustomerId",
                table: "Item_Costomer_Wishes",
                column: "CustomerWishListCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Costomer_Wishes_Items_CustomerWishListItemId",
                table: "Item_Costomer_Wishes",
                column: "CustomerWishListItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Customer_Likes_Customers_ItemLikesCustomerId",
                table: "Item_Customer_Likes",
                column: "ItemLikesCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Customer_Likes_Items_ItemLikesItemId",
                table: "Item_Customer_Likes",
                column: "ItemLikesItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Costomer_Wishes_Customers_CustomerWishListCustomerId",
                table: "Item_Costomer_Wishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Costomer_Wishes_Items_CustomerWishListItemId",
                table: "Item_Costomer_Wishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Customer_Likes_Customers_ItemLikesCustomerId",
                table: "Item_Customer_Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Customer_Likes_Items_ItemLikesItemId",
                table: "Item_Customer_Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item_Customer_Likes",
                table: "Item_Customer_Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item_Costomer_Wishes",
                table: "Item_Costomer_Wishes");

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

            migrationBuilder.RenameTable(
                name: "Item_Customer_Likes",
                newName: "CustomerItem");

            migrationBuilder.RenameTable(
                name: "Item_Costomer_Wishes",
                newName: "CustomerItem1");

            migrationBuilder.RenameIndex(
                name: "IX_Item_Customer_Likes_ItemLikesItemId",
                table: "CustomerItem",
                newName: "IX_CustomerItem_ItemLikesItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_Costomer_Wishes_CustomerWishListItemId",
                table: "CustomerItem1",
                newName: "IX_CustomerItem1_CustomerWishListItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerItem",
                table: "CustomerItem",
                columns: new[] { "ItemLikesCustomerId", "ItemLikesItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerItem1",
                table: "CustomerItem1",
                columns: new[] { "CustomerWishListCustomerId", "CustomerWishListItemId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2121f5e9-19df-45cc-a43d-737f1cf7bae4", "cf9ce213-00c5-4e3d-a3bf-2a8a9658b038", "Admin", "ADMIN" },
                    { "4f25d739-730c-4cc1-b514-322e74338ac7", "1d2e4513-f5b4-40f8-91ac-7fb23003b787", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("201a50b9-2b0d-4d31-9228-bf0a76a278b2"), "Pluszak" },
                    { new Guid("414d95f5-765b-407e-8c32-bcba94adc248"), "Szalik" },
                    { new Guid("d9f868c2-3d98-4320-8f86-93158c25db1f"), "Czapka" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerItem_Customers_ItemLikesCustomerId",
                table: "CustomerItem",
                column: "ItemLikesCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerItem_Items_ItemLikesItemId",
                table: "CustomerItem",
                column: "ItemLikesItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerItem1_Customers_CustomerWishListCustomerId",
                table: "CustomerItem1",
                column: "CustomerWishListCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerItem1_Items_CustomerWishListItemId",
                table: "CustomerItem1",
                column: "CustomerWishListItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
