using Microsoft.EntityFrameworkCore.Migrations;

namespace StockSystem.Migrations
{
    public partial class modifyInStockSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "SS_InStockSummary",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "SS_InStockSummary");
        }
    }
}
