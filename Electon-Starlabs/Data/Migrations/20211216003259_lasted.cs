using Microsoft.EntityFrameworkCore.Migrations;

namespace Electon_Starlabs.Data.Migrations
{
    public partial class lasted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "BueyerLastName",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "OrderItems");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ShoppingCartItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "ShoppingCartItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "ShoppingCartItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "ShoppingCartItems");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BueyerLastName",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerName",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
