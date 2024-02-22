using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSalesHeaderAndSalesLineTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "SalesLines");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "SalesLines");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "SalesHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExchangeRate",
                table: "SalesHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "SalesHeaders");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "SalesHeaders");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "SalesLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExchangeRate",
                table: "SalesLines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
