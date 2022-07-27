using Microsoft.EntityFrameworkCore.Migrations;

namespace DKMart.Migrations
{
    public partial class detailImageToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailImages",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailImages",
                table: "Products");
        }
    }
}
