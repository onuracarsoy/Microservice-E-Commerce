using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Order.Persistence.Migrations
{
    public partial class updateorderingPriceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "OrderTotalPrice",
                table: "Orderings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderTotalPrice",
                table: "Orderings",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
