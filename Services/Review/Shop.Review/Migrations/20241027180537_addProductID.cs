using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Review.Migrations
{
    public partial class addProductID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductID",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Comments");
        }
    }
}
