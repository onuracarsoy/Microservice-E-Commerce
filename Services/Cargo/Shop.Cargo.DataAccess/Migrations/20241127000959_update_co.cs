using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Cargo.DataAccess.Migrations
{
    public partial class update_co : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CargoStepFive",
                table: "CargoOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoStepFive",
                table: "CargoOperations");
        }
    }
}
