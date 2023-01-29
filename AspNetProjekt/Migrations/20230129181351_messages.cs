using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class messages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item_Costomer_Wishes");

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

            migrationBuilder.CreateTable(
                name: "customerWishItems",
                columns: table => new
                {
                    CustomerWishItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerWishItems", x => x.CustomerWishItemId);
                    table.ForeignKey(
                        name: "FK_customerWishItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customerWishItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customerWishItemMessages",
                columns: table => new
                {
                    CustomerWishItemMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerWishItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Viewed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerWishItemMessages", x => x.CustomerWishItemMessageId);
                    table.ForeignKey(
                        name: "FK_customerWishItemMessages_customerWishItems_CustomerWishItemId",
                        column: x => x.CustomerWishItemId,
                        principalTable: "customerWishItems",
                        principalColumn: "CustomerWishItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "465c6b28-26ff-438b-b13d-1e91f2a5469f", "2259cb55-4154-4f34-ad59-7a499724feac", "Admin", "ADMIN" },
                    { "e2e0ac5a-d6c0-474c-93cb-e59e9f0eaeef", "2d1e5b64-786a-4a09-9297-3878390641ee", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("a9273c20-3cee-48c6-adc1-1a9baf26c4bc"), "Czapka" },
                    { new Guid("b972a6ff-87ee-4513-94e3-19884c2e14c9"), "Pluszak" },
                    { new Guid("cf73100c-a541-41ff-86cb-4b942ce2e90a"), "Szalik" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemAvalibility", "ItemDescription", "ItemDiscount", "ItemImageName", "ItemName", "ItemPrice" },
                values: new object[,]
                {
                    { new Guid("40968a72-a5d8-4a68-9621-0356c4ac5680"), 2, "Duży pluszowy ręcznie wykonany miś", 0, null, "Pluszowy miś", 70m },
                    { new Guid("6c4b0473-3635-4838-8f48-e893ff439407"), 0, "Bardzo ciepła ręcznie wykonana czapka", 0, null, "Szara czapka", 70m },
                    { new Guid("6c69beec-85f4-4a54-8bff-a44ca69061ad"), 1, "Bardzo ciepła ręcznie wykonana czapka", 0, null, "Biała czapka", 110m },
                    { new Guid("7b74e3b1-8df5-4c3e-b09d-c5817004c90e"), 0, "Bardzo ciepły ręcznie wykonany szalik", 0, null, "Granatowy Szalik", 100m },
                    { new Guid("88a47289-9721-4372-acab-c80b603091d4"), 10, "Bardzo ciepły ręcznie wykonany szalik", 30, null, "Czarny szalik", 120m },
                    { new Guid("ade2f7e9-8548-44f0-beb2-eceac9cd2a2e"), 3, "Zielona szydełkowa żaba, wykonana ręcznie z mięciutkiej włóczki", 10, null, "Szydełkowa Żaba", 100m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_customerWishItemMessages_CustomerWishItemId",
                table: "customerWishItemMessages",
                column: "CustomerWishItemId");

            migrationBuilder.CreateIndex(
                name: "IX_customerWishItems_CustomerId",
                table: "customerWishItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_customerWishItems_ItemId",
                table: "customerWishItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerWishItemMessages");

            migrationBuilder.DropTable(
                name: "customerWishItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "465c6b28-26ff-438b-b13d-1e91f2a5469f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2e0ac5a-d6c0-474c-93cb-e59e9f0eaeef");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("a9273c20-3cee-48c6-adc1-1a9baf26c4bc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("b972a6ff-87ee-4513-94e3-19884c2e14c9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("cf73100c-a541-41ff-86cb-4b942ce2e90a"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("40968a72-a5d8-4a68-9621-0356c4ac5680"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("6c4b0473-3635-4838-8f48-e893ff439407"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("6c69beec-85f4-4a54-8bff-a44ca69061ad"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("7b74e3b1-8df5-4c3e-b09d-c5817004c90e"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("88a47289-9721-4372-acab-c80b603091d4"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("ade2f7e9-8548-44f0-beb2-eceac9cd2a2e"));

            migrationBuilder.CreateTable(
                name: "Item_Costomer_Wishes",
                columns: table => new
                {
                    CustomerWishListCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerWishListItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_Costomer_Wishes", x => new { x.CustomerWishListCustomerId, x.CustomerWishListItemId });
                    table.ForeignKey(
                        name: "FK_Item_Costomer_Wishes_Customers_CustomerWishListCustomerId",
                        column: x => x.CustomerWishListCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Costomer_Wishes_Items_CustomerWishListItemId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Item_Costomer_Wishes_CustomerWishListItemId",
                table: "Item_Costomer_Wishes",
                column: "CustomerWishListItemId");
        }
    }
}
