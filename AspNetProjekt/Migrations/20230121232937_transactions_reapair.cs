using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class transactions_reapair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions");

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
                name: "TransactionId",
                table: "Customers");

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
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions");

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
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId",
                unique: true);
        }
    }
}
