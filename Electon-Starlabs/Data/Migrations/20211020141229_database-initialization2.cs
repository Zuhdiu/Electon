using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Electon_Starlabs.Data.Migrations
{
    public partial class databaseinitialization2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_IdentityUserId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_CustomerId1",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_CustomerId1",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_AspNetUsers_CustomerId1",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_CustomerId1",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_CustomerId1",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_CustomerId1",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdentityUserId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "WishList");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Locked",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true),
                    Locked = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishList_CustomerId",
                table: "WishList",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerId",
                table: "ShoppingCart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerId",
                table: "Reviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityUserId",
                table: "Customers",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Customers_CustomerId",
                table: "ShoppingCart",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_Customers_CustomerId",
                table: "WishList",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Customers_CustomerId",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_Customers_CustomerId",
                table: "WishList");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_WishList_CustomerId",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_CustomerId",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_CustomerId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "WishList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "ShoppingCart",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityUserId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_CustomerId1",
                table: "WishList",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerId1",
                table: "ShoppingCart",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerId1",
                table: "Reviews",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId1",
                table: "Orders",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdentityUserId1",
                table: "AspNetUsers",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_IdentityUserId1",
                table: "AspNetUsers",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId1",
                table: "Orders",
                column: "CustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_CustomerId1",
                table: "Reviews",
                column: "CustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_CustomerId1",
                table: "ShoppingCart",
                column: "CustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_AspNetUsers_CustomerId1",
                table: "WishList",
                column: "CustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
