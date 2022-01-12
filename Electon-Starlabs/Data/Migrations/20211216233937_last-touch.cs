using Microsoft.EntityFrameworkCore.Migrations;

namespace Electon_Starlabs.Data.Migrations
{
    public partial class lasttouch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "OrderItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "OrderItems");
        }
    }
}
