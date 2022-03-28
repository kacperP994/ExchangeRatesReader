using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeRatesReader.Migrations
{
    public partial class ADeleteCountryColumnFromEntityCurrencyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Currencies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
