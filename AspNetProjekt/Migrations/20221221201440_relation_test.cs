using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class relation_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("703cbb19-476a-4dd5-9053-900408adfadf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("77e92b7d-cf18-4cf6-89ab-7f1ea8a7eddc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("867efe41-9173-4abd-a9d9-cdd5ce347af2"));

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
                column: "CategoryId",
                value: new Guid("bc730018-635c-43ce-8e81-d95d17390532"));

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: new Guid("dba5f9dc-d04b-4d98-9c3f-b899f2d6d935"));

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: new Guid("ea0cda19-a8f4-4d7e-9abb-1f81ce76e4ad"));

            migrationBuilder.CreateIndex(
                name: "IX_ItemUserShoppingCart_userShoppingCartsUserId",
                table: "ItemUserShoppingCart",
                column: "userShoppingCartsUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemUserShoppingCart");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("bc730018-635c-43ce-8e81-d95d17390532"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("dba5f9dc-d04b-4d98-9c3f-b899f2d6d935"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("ea0cda19-a8f4-4d7e-9abb-1f81ce76e4ad"));

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: new Guid("703cbb19-476a-4dd5-9053-900408adfadf"));

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: new Guid("77e92b7d-cf18-4cf6-89ab-7f1ea8a7eddc"));

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: new Guid("867efe41-9173-4abd-a9d9-cdd5ce347af2"));
        }
    }
}
