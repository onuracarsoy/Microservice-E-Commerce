using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Order.Persistence.Migrations
{
    public partial class orderAddressUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Orderings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_AddressID",
                table: "Orderings",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_Addresses_AddressID",
                table: "Orderings",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_Addresses_AddressID",
                table: "Orderings");

            migrationBuilder.DropIndex(
                name: "IX_Orderings_AddressID",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Orderings");
        }
    }
}
