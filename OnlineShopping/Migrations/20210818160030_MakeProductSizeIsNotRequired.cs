using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class MakeProductSizeIsNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSize_ProductSizeID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductSizeID",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSize_ProductSizeID",
                table: "Products",
                column: "ProductSizeID",
                principalTable: "ProductSize",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSize_ProductSizeID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductSizeID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSize_ProductSizeID",
                table: "Products",
                column: "ProductSizeID",
                principalTable: "ProductSize",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
