using Microsoft.EntityFrameworkCore.Migrations;

namespace Electon_Starlabs.Data.Migrations
{
    public partial class addedCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ShoppingCart");
        }
    }
}
