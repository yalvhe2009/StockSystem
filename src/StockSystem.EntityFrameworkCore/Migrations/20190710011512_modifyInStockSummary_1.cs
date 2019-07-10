using Microsoft.EntityFrameworkCore.Migrations;

namespace StockSystem.Migrations
{
    public partial class modifyInStockSummary_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStockNumber",
                table: "SS_InStockSummary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InStockNumber",
                table: "SS_InStockSummary",
                nullable: false,
                defaultValue: "");
        }
    }
}
