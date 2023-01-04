using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_IdentityUserId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "ItemUserShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Customers_IdentityUserId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("4865b970-a77b-4d0c-a656-361343a42342"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("653f53ad-377f-485d-b2e4-0274795e6120"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c2d0d637-1642-431a-bc0f-5c61ce0c6c29"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UsersWishLists",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UsersShoppingCarts",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ItemsLikes",
                newName: "CustomerId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ItemPrice",
                table: "Transaction_Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ItemAvalibility",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ItemPrice",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                        name: "FK_CustomerShoppingCartItem_Items_ItemsItemId",
                        column: x => x.ItemsItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerShoppingCartItem_UsersShoppingCarts_CustomerShoppingCartsCustomerId",
                        column: x => x.CustomerShoppingCartsCustomerId,
                        principalTable: "UsersShoppingCarts",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("3bbed082-552c-498d-9302-a08e256ef868"), "Czapka" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("57ae6bd9-1c2d-483e-9d98-ea817b72816a"), "Pluszak" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("9573caf2-c342-4029-bac2-aa3aed1d01c4"), "Szalik" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersWishLists_CustomerId",
                table: "UsersWishLists",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsLikes_CustomerId",
                table: "ItemsLikes",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityUserId",
                table: "Customers",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerShoppingCartItem_ItemsItemId",
                table: "CustomerShoppingCartItem",
                column: "ItemsItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_IdentityUserId",
                table: "Customers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsLikes_Customers_CustomerId",
                table: "ItemsLikes",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions",
                column: "CustomerId",
                principalTable: "Customers",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_IdentityUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsLikes_Customers_CustomerId",
                table: "ItemsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersShoppingCarts_Customers_CustomerId",
                table: "UsersShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersWishLists_Customers_CustomerId",
                table: "UsersWishLists");

            migrationBuilder.DropTable(
                name: "CustomerShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_UsersWishLists_CustomerId",
                table: "UsersWishLists");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_ItemsLikes_CustomerId",
                table: "ItemsLikes");

            migrationBuilder.DropIndex(
                name: "IX_Customers_IdentityUserId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("3bbed082-552c-498d-9302-a08e256ef868"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("57ae6bd9-1c2d-483e-9d98-ea817b72816a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("9573caf2-c342-4029-bac2-aa3aed1d01c4"));

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "Transaction_Items");

            migrationBuilder.DropColumn(
                name: "ItemAvalibility",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "UsersWishLists",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "UsersShoppingCarts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ItemsLikes",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ItemUserShoppingCart",
                columns: table => new
                {
                    ItemsItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userShoppingCartsUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemUserShoppingCart", x => new { x.ItemsItemId, x.userShoppingCartsUserId });
                    table.ForeignKey(
                        name: "FK_ItemUserShoppingCart_Items_ItemsItemId",
                        column: x => x.ItemsItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemUserShoppingCart_UsersShoppingCarts_userShoppingCartsUserId",
                        column: x => x.userShoppingCartsUserId,
                        principalTable: "UsersShoppingCarts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("4865b970-a77b-4d0c-a656-361343a42342"), "Szalik" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("653f53ad-377f-485d-b2e4-0274795e6120"), "Pluszak" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("c2d0d637-1642-431a-bc0f-5c61ce0c6c29"), "Czapka" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityUserId",
                table: "Customers",
                column: "IdentityUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemUserShoppingCart_userShoppingCartsUserId",
                table: "ItemUserShoppingCart",
                column: "userShoppingCartsUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_IdentityUserId",
                table: "Customers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
