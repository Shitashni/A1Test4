using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandicraftStore.Data.Migrations
{
    public partial class currencytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExchangeRate",
                table: "ExchangeRate");

            migrationBuilder.RenameTable(
                name: "ExchangeRate",
                newName: "ExchangeRates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExchangeRates",
                table: "ExchangeRates",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExchangeRates",
                table: "ExchangeRates");

            migrationBuilder.RenameTable(
                name: "ExchangeRates",
                newName: "ExchangeRate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExchangeRate",
                table: "ExchangeRate",
                column: "Id");
        }
    }
}
