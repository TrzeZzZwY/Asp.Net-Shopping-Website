using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class likes_and_wishes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersWishLists");

            migrationBuilder.DropTable(
                name: "ItemsLikes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a3fd582-52eb-47fb-8a34-ed948dbe2428");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1823d69-0ab3-4fc2-982e-8ed71875c3d8");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("39130fa0-d2e9-4602-aac2-6c6e43c1a0a8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("4283319b-fa60-4a77-923b-874bba304d00"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("e8ac85fd-7241-4615-a3cb-d0a5d5d23938"));

            migrationBuilder.DropColumn(
                name: "CustomerWishListId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ItemLikesId",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "CustomerItem",
                columns: table => new
                {
                    ItemLikesCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemLikesItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerItem", x => new { x.ItemLikesCustomerId, x.ItemLikesItemId });
                    table.ForeignKey(
                        name: "FK_CustomerItem_Customers_ItemLikesCustomerId",
                        column: x => x.ItemLikesCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerItem_Items_ItemLikesItemId",
                        column: x => x.ItemLikesItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerItem1",
                columns: table => new
                {
                    CustomerWishListCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerWishListItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerItem1", x => new { x.CustomerWishListCustomerId, x.CustomerWishListItemId });
                    table.ForeignKey(
                        name: "FK_CustomerItem1_Customers_CustomerWishListCustomerId",
                        column: x => x.CustomerWishListCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerItem1_Items_CustomerWishListItemId",
                        column: x => x.CustomerWishListItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerItem_ItemLikesItemId",
                table: "CustomerItem",
                column: "ItemLikesItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerItem1_CustomerWishListItemId",
                table: "CustomerItem1",
                column: "CustomerWishListItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerItem");

            migrationBuilder.DropTable(
                name: "CustomerItem1");

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

            migrationBuilder.CreateTable(
                name: "CustomersWishLists",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersWishLists", x => new { x.CustomerId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_CustomersWishLists_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersWishLists_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsLikes",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsLikes", x => new { x.CustomerId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemsLikes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsLikes_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a3fd582-52eb-47fb-8a34-ed948dbe2428", "5af9e5e5-0e0a-4a56-9292-a344b1266128", "User", "USER" },
                    { "e1823d69-0ab3-4fc2-982e-8ed71875c3d8", "312653b8-134a-4eb7-82ea-049c77a45b8f", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("39130fa0-d2e9-4602-aac2-6c6e43c1a0a8"), "Czapka" },
                    { new Guid("4283319b-fa60-4a77-923b-874bba304d00"), "Szalik" },
                    { new Guid("e8ac85fd-7241-4615-a3cb-d0a5d5d23938"), "Pluszak" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersWishLists_CustomerId",
                table: "CustomersWishLists",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersWishLists_ItemId",
                table: "CustomersWishLists",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsLikes_CustomerId",
                table: "ItemsLikes",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsLikes_ItemId",
                table: "ItemsLikes",
                column: "ItemId");
        }
    }
}
