using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class AddArabicCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArabicName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArabicName",
                table: "Categories");
        }
    }
}
