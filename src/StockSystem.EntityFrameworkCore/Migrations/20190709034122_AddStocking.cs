using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockSystem.Migrations
{
    public partial class AddStocking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SS_Stocking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StockingNumber = table.Column<int>(nullable: false),
                    GoodsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SS_Stocking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SS_Stocking_SS_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "SS_Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SS_Stocking_GoodsId",
                table: "SS_Stocking",
                column: "GoodsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SS_Stocking");
        }
    }
}
