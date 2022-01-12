using Microsoft.EntityFrameworkCore.Migrations;

namespace Electon_Starlabs.Data.Migrations
{
    public partial class addedsomethingonShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Customers_CustomerId",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Products_ProductId",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_CustomerId",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ShoppingCart",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_ProductId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_productId");

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "ShoppingCart",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ShoppingCartId",
                table: "ShoppingCart",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Products_productId",
                table: "ShoppingCart",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Products_productId",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "ShoppingCart",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_productId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerId",
                table: "ShoppingCart",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Customers_CustomerId",
                table: "ShoppingCart",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Products_ProductId",
                table: "ShoppingCart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
