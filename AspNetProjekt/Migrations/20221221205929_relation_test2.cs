using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class relation_test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transactions",
                newName: "TransactionId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Items_ItemId",
                table: "Transaction_Items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsLikes_ItemId",
                table: "ItemsLikes",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsLikes_Items_ItemId",
                table: "ItemsLikes",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ItemsLikes_Items_ItemId",
                table: "ItemsLikes");

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
                name: "IX_ItemsLikes_ItemId",
                table: "ItemsLikes");

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

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transactions",
                newName: "UserId");

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
        }
    }
}
