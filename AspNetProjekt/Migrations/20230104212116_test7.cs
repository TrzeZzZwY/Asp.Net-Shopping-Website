using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetProjekt.Migrations
{
    public partial class test7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "ItemDiscout",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("26a2e4cc-44d6-4309-906e-e8139e03bd4f"), "Pluszak" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("463fa8e1-d023-4434-910c-e3984c111cf6"), "Szalik" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("c9a23282-9993-438c-bb82-32d5d27c4a0a"), "Czapka" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("26a2e4cc-44d6-4309-906e-e8139e03bd4f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("463fa8e1-d023-4434-910c-e3984c111cf6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c9a23282-9993-438c-bb82-32d5d27c4a0a"));

            migrationBuilder.DropColumn(
                name: "ItemDiscout",
                table: "Items");

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
        }
    }
}
