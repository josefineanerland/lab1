using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Joane_Labb1.Data.Migrations
{
    public partial class ProductsToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Orderdate",
                table: "OrderModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Products",
                table: "OrderModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orderdate",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "Products",
                table: "OrderModel");
        }
    }
}
