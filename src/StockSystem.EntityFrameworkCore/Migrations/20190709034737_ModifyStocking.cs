using Microsoft.EntityFrameworkCore.Migrations;

namespace StockSystem.Migrations
{
    public partial class ModifyStocking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SS_Stocking_SS_Goods_GoodsId",
                table: "SS_Stocking");

            migrationBuilder.AlterColumn<int>(
                name: "GoodsId",
                table: "SS_Stocking",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SS_Stocking_SS_Goods_GoodsId",
                table: "SS_Stocking",
                column: "GoodsId",
                principalTable: "SS_Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SS_Stocking_SS_Goods_GoodsId",
                table: "SS_Stocking");

            migrationBuilder.AlterColumn<int>(
                name: "GoodsId",
                table: "SS_Stocking",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SS_Stocking_SS_Goods_GoodsId",
                table: "SS_Stocking",
                column: "GoodsId",
                principalTable: "SS_Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
