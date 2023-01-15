using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class try_add_getters_and_setters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customerShoppingCart_Items_CustomersShoppingCarts_CustomerShoppingCartCustomerId",
                table: "customerShoppingCart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_customerShoppingCart_Items_Items_ItemId1",
                table: "customerShoppingCart_Items");

            migrationBuilder.DropIndex(
                name: "IX_customerShoppingCart_Items_CustomerShoppingCartCustomerId",
                table: "customerShoppingCart_Items");

            migrationBuilder.DropIndex(
                name: "IX_customerShoppingCart_Items_ItemId1",
                table: "customerShoppingCart_Items");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22c0032f-0cf6-4695-a30c-0d84558a62fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c018716-031e-44da-a769-d517ca8c4df5");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("2c878ab1-2c25-4d33-82f9-f9b61ac652be"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c29a4d62-eec8-43cf-9bac-e657d01ff0a3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("e323aa55-cbdb-4347-a9c7-027634c0545a"));

            migrationBuilder.DropColumn(
                name: "CustomerShoppingCartCustomerId",
                table: "customerShoppingCart_Items");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                table: "customerShoppingCart_Items");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerShoppingCartId",
                table: "customerShoppingCart_Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "customerShoppingCart_Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02c3498f-432a-4cf6-b863-6d640a18d33b", "eaa5f63a-9b19-4efb-ac4a-ba1102dc026a", "Admin", "ADMIN" },
                    { "44a07b65-5847-4882-8003-1d35dafbe9f9", "662190b5-d5c9-46eb-a264-2a92f8e5dee3", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("21e42ca4-df01-4b70-bcbd-0fa1f4feb727"), "Szalik" },
                    { new Guid("7f7e31e9-f829-4e8e-bb1c-dea03bba0dad"), "Czapka" },
                    { new Guid("9316d2d1-7d09-4e67-ac54-25f4db0dffed"), "Pluszak" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_customerShoppingCart_Items_CustomerShoppingCartId",
                table: "customerShoppingCart_Items",
                column: "CustomerShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_customerShoppingCart_Items_ItemId",
                table: "customerShoppingCart_Items",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_customerShoppingCart_Items_CustomersShoppingCarts_CustomerShoppingCartId",
                table: "customerShoppingCart_Items",
                column: "CustomerShoppingCartId",
                principalTable: "CustomersShoppingCarts",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customerShoppingCart_Items_Items_ItemId",
                table: "customerShoppingCart_Items",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customerShoppingCart_Items_CustomersShoppingCarts_CustomerShoppingCartId",
                table: "customerShoppingCart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_customerShoppingCart_Items_Items_ItemId",
                table: "customerShoppingCart_Items");

            migrationBuilder.DropIndex(
                name: "IX_customerShoppingCart_Items_CustomerShoppingCartId",
                table: "customerShoppingCart_Items");

            migrationBuilder.DropIndex(
                name: "IX_customerShoppingCart_Items_ItemId",
                table: "customerShoppingCart_Items");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02c3498f-432a-4cf6-b863-6d640a18d33b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44a07b65-5847-4882-8003-1d35dafbe9f9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("21e42ca4-df01-4b70-bcbd-0fa1f4feb727"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("7f7e31e9-f829-4e8e-bb1c-dea03bba0dad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("9316d2d1-7d09-4e67-ac54-25f4db0dffed"));

            migrationBuilder.DropColumn(
                name: "CustomerShoppingCartId",
                table: "customerShoppingCart_Items");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "customerShoppingCart_Items");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerShoppingCartCustomerId",
                table: "customerShoppingCart_Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId1",
                table: "customerShoppingCart_Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22c0032f-0cf6-4695-a30c-0d84558a62fc", "4048a8df-9603-49a7-813a-d083b30f5e6d", "User", "USER" },
                    { "4c018716-031e-44da-a769-d517ca8c4df5", "cdd22e70-5a4b-48d6-b835-2df680d05ea7", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("2c878ab1-2c25-4d33-82f9-f9b61ac652be"), "Pluszak" },
                    { new Guid("c29a4d62-eec8-43cf-9bac-e657d01ff0a3"), "Czapka" },
                    { new Guid("e323aa55-cbdb-4347-a9c7-027634c0545a"), "Szalik" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_customerShoppingCart_Items_CustomerShoppingCartCustomerId",
                table: "customerShoppingCart_Items",
                column: "CustomerShoppingCartCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_customerShoppingCart_Items_ItemId1",
                table: "customerShoppingCart_Items",
                column: "ItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_customerShoppingCart_Items_CustomersShoppingCarts_CustomerShoppingCartCustomerId",
                table: "customerShoppingCart_Items",
                column: "CustomerShoppingCartCustomerId",
                principalTable: "CustomersShoppingCarts",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_customerShoppingCart_Items_Items_ItemId1",
                table: "customerShoppingCart_Items",
                column: "ItemId1",
                principalTable: "Items",
                principalColumn: "ItemId");
        }
    }
}
