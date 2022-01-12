using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Electon_Starlabs.Data.Migrations
{
    public partial class DataTimeatReviewModeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "Reviews");
        }
    }
}
