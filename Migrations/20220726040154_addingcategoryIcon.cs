using Microsoft.EntityFrameworkCore.Migrations;

namespace DKMart.Migrations
{
    public partial class addingcategoryIcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CatImageIcon",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatImageIcon",
                table: "Category");
        }
    }
}
