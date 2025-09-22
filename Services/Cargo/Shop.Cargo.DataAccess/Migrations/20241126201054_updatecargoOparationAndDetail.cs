using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Cargo.DataAccess.Migrations
{
    public partial class updatecargoOparationAndDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CargoDetailBarcode",
                table: "CargoDetails",
                newName: "OrderingID");

            migrationBuilder.AddColumn<bool>(
                name: "CargoStepFour",
                table: "CargoOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CargoStepOne",
                table: "CargoOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CargoStepThree",
                table: "CargoOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CargoStepTwo",
                table: "CargoOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CargoCustomerID",
                table: "CargoDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CargoOperationID",
                table: "CargoDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_CargoCustomerID",
                table: "CargoDetails",
                column: "CargoCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_CargoOperationID",
                table: "CargoDetails",
                column: "CargoOperationID");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoDetails_CargoCustomers_CargoCustomerID",
                table: "CargoDetails",
                column: "CargoCustomerID",
                principalTable: "CargoCustomers",
                principalColumn: "CargoCustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CargoDetails_CargoOperations_CargoOperationID",
                table: "CargoDetails",
                column: "CargoOperationID",
                principalTable: "CargoOperations",
                principalColumn: "CargoOperationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoDetails_CargoCustomers_CargoCustomerID",
                table: "CargoDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CargoDetails_CargoOperations_CargoOperationID",
                table: "CargoDetails");

            migrationBuilder.DropIndex(
                name: "IX_CargoDetails_CargoCustomerID",
                table: "CargoDetails");

            migrationBuilder.DropIndex(
                name: "IX_CargoDetails_CargoOperationID",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "CargoStepFour",
                table: "CargoOperations");

            migrationBuilder.DropColumn(
                name: "CargoStepOne",
                table: "CargoOperations");

            migrationBuilder.DropColumn(
                name: "CargoStepThree",
                table: "CargoOperations");

            migrationBuilder.DropColumn(
                name: "CargoStepTwo",
                table: "CargoOperations");

            migrationBuilder.DropColumn(
                name: "CargoCustomerID",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "CargoOperationID",
                table: "CargoDetails");

            migrationBuilder.RenameColumn(
                name: "OrderingID",
                table: "CargoDetails",
                newName: "CargoDetailBarcode");
        }
    }
}
