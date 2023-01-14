using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class shoppingCartFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Items_Items_ItemId",
                table: "Transaction_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Items_Transactions_TransactionId",
                table: "Transaction_Items");

            migrationBuilder.DropTable(
                name: "CustomerShoppingCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction_Items",
                table: "Transaction_Items");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_Items_ItemId",
                table: "Transaction_Items");

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

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Transaction_Items");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Transaction_Items",
                newName: "Transaction_ItemId");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId1",
                table: "Transaction_Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId1",
                table: "Transaction_Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction_Items",
                table: "Transaction_Items",
                column: "Transaction_ItemId");

            migrationBuilder.CreateTable(
                name: "customerShoppingCart_Items",
                columns: table => new
                {
                    CustomerShoppingCart_ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerShoppingCartCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerShoppingCart_Items", x => x.CustomerShoppingCart_ItemId);
                    table.ForeignKey(
                        name: "FK_customerShoppingCart_Items_CustomersShoppingCarts_CustomerShoppingCartCustomerId",
                        column: x => x.CustomerShoppingCartCustomerId,
                        principalTable: "CustomersShoppingCarts",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_customerShoppingCart_Items_Items_ItemId1",
                        column: x => x.ItemId1,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                });

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
                name: "IX_Transaction_Items_ItemId1",
                table: "Transaction_Items",
                column: "ItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Items_TransactionId1",
                table: "Transaction_Items",
                column: "TransactionId1");

            migrationBuilder.CreateIndex(
                name: "IX_customerShoppingCart_Items_CustomerShoppingCartCustomerId",
                table: "customerShoppingCart_Items",
                column: "CustomerShoppingCartCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_customerShoppingCart_Items_ItemId1",
                table: "customerShoppingCart_Items",
                column: "ItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Items_Items_ItemId1",
                table: "Transaction_Items",
                column: "ItemId1",
                principalTable: "Items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Items_Transactions_TransactionId1",
                table: "Transaction_Items",
                column: "TransactionId1",
                principalTable: "Transactions",
                principalColumn: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Items_Items_ItemId1",
                table: "Transaction_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Items_Transactions_TransactionId1",
                table: "Transaction_Items");

            migrationBuilder.DropTable(
                name: "customerShoppingCart_Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction_Items",
                table: "Transaction_Items");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_Items_ItemId1",
                table: "Transaction_Items");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_Items_TransactionId1",
                table: "Transaction_Items");

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
                name: "ItemId1",
                table: "Transaction_Items");

            migrationBuilder.DropColumn(
                name: "TransactionId1",
                table: "Transaction_Items");

            migrationBuilder.RenameColumn(
                name: "Transaction_ItemId",
                table: "Transaction_Items",
                newName: "ItemId");

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "Transaction_Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction_Items",
                table: "Transaction_Items",
                columns: new[] { "TransactionId", "ItemId" });

            migrationBuilder.CreateTable(
                name: "CustomerShoppingCartItem",
                columns: table => new
                {
                    CustomerShoppingCartsCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemsItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerShoppingCartItem", x => new { x.CustomerShoppingCartsCustomerId, x.ItemsItemId });
                    table.ForeignKey(
                        name: "FK_CustomerShoppingCartItem_CustomersShoppingCarts_CustomerShoppingCartsCustomerId",
                        column: x => x.CustomerShoppingCartsCustomerId,
                        principalTable: "CustomersShoppingCarts",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerShoppingCartItem_Items_ItemsItemId",
                        column: x => x.ItemsItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Items_ItemId",
                table: "Transaction_Items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerShoppingCartItem_ItemsItemId",
                table: "CustomerShoppingCartItem",
                column: "ItemsItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Items_Items_ItemId",
                table: "Transaction_Items",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Items_Transactions_TransactionId",
                table: "Transaction_Items",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
