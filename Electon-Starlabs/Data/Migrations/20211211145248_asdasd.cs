using Microsoft.EntityFrameworkCore.Migrations;

namespace Electon_Starlabs.Data.Migrations
{
    public partial class asdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Products_productId",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "ShoppingCartItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_productId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Products_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Products_ProductId",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ShoppingCartItems",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_productId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Products_productId",
                table: "ShoppingCartItems",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
