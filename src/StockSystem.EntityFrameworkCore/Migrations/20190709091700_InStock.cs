using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockSystem.Migrations
{
    public partial class InStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SS_InStockSummary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InStockNumber = table.Column<string>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    OperatingTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SS_InStockSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SS_InStockSummary_SS_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "SS_Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SS_InStockSummary_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SS_InStockDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InStockSummaryId = table.Column<int>(nullable: false),
                    GoodsId = table.Column<int>(nullable: false),
                    InStockAmount = table.Column<int>(nullable: false),
                    InStockPrice = table.Column<decimal>(nullable: false),
                    InStockSumPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SS_InStockDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SS_InStockDetail_SS_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "SS_Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SS_InStockDetail_SS_InStockSummary_InStockSummaryId",
                        column: x => x.InStockSummaryId,
                        principalTable: "SS_InStockSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SS_InStockDetail_GoodsId",
                table: "SS_InStockDetail",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_SS_InStockDetail_InStockSummaryId",
                table: "SS_InStockDetail",
                column: "InStockSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_SS_InStockSummary_SupplierId",
                table: "SS_InStockSummary",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SS_InStockSummary_UserId",
                table: "SS_InStockSummary",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SS_InStockDetail");

            migrationBuilder.DropTable(
                name: "SS_InStockSummary");
        }
    }
}
