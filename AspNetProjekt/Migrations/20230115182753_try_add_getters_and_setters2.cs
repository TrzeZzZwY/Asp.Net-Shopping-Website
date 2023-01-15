using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class try_add_getters_and_setters2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Items_Items_ItemId1",
                table: "Transaction_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Items_Transactions_TransactionId1",
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
                name: "ItemId1",
                table: "Transaction_Items");

            migrationBuilder.DropColumn(
                name: "TransactionId1",
                table: "Transaction_Items");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Transaction_Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "Transaction_Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerShoppingCartsId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerWishListId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ItemLikesId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fecc050-7066-4853-b838-f858b3e14405", "b62dfca9-8d10-4696-a745-1a2fbb1a9f1a", "User", "USER" },
                    { "925f9a8a-474b-4651-ad8d-49a6215b392e", "844db6fb-0583-4279-a89c-bb2fcb27c9a2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("5321ce88-885c-47f7-869c-97fa539ab435"), "Czapka" },
                    { new Guid("966fce01-fd7b-4478-9b9e-d3efd46680e1"), "Szalik" },
                    { new Guid("e60b53aa-e53d-4488-ad5e-339ac3601e62"), "Pluszak" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Items_ItemId",
                table: "Transaction_Items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Items_TransactionId",
                table: "Transaction_Items",
                column: "TransactionId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Items_Items_ItemId",
                table: "Transaction_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Items_Transactions_TransactionId",
                table: "Transaction_Items");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_Items_ItemId",
                table: "Transaction_Items");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_Items_TransactionId",
                table: "Transaction_Items");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fecc050-7066-4853-b838-f858b3e14405");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "925f9a8a-474b-4651-ad8d-49a6215b392e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("5321ce88-885c-47f7-869c-97fa539ab435"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("966fce01-fd7b-4478-9b9e-d3efd46680e1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("e60b53aa-e53d-4488-ad5e-339ac3601e62"));

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Transaction_Items");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Transaction_Items");

            migrationBuilder.DropColumn(
                name: "CustomerShoppingCartsId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerWishListId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ItemLikesId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Customers");

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
                name: "IX_Transaction_Items_ItemId1",
                table: "Transaction_Items",
                column: "ItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Items_TransactionId1",
                table: "Transaction_Items",
                column: "TransactionId1");

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
    }
}
