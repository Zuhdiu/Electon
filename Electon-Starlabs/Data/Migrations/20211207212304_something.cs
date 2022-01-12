using Microsoft.EntityFrameworkCore.Migrations;

namespace Electon_Starlabs.Data.Migrations
{
    public partial class something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItemsB_Products_productId",
                table: "ShoppingCartItemsB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItemsB",
                table: "ShoppingCartItemsB");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItemsB",
                newName: "ShoppingCartItems");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItemsB_productId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_productId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Products_productId",
                table: "ShoppingCartItems",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Products_productId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItems",
                newName: "ShoppingCartItemsB");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_productId",
                table: "ShoppingCartItemsB",
                newName: "IX_ShoppingCartItemsB_productId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItemsB",
                table: "ShoppingCartItemsB",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItemsB_Products_productId",
                table: "ShoppingCartItemsB",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
