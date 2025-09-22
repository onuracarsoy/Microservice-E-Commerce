using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Order.Persistence.Migrations
{
    public partial class updateOrderCargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CargoDetailID",
                table: "Orderings",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoDetailID",
                table: "Orderings");
        }
    }
}
