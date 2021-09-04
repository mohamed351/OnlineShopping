using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class AddUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeactivate",
                table: "ApplicationUser",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ApplicationUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ApplicationUser");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ApplicationUser",
                newName: "IsDeactivate");
        }
    }
}
