using Microsoft.EntityFrameworkCore.Migrations;

namespace DKMart.Migrations
{
    public partial class detailImage1toDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailImages1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailImages1",
                table: "Products");
        }
    }
}
