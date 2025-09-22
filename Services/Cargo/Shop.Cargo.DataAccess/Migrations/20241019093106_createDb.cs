using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Cargo.DataAccess.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargoCompanies",
                columns: table => new
                {
                    CargoCompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoCompanies", x => x.CargoCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "CargoCustomers",
                columns: table => new
                {
                    CargoCustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoCustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCustomerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCustomerDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoCustomers", x => x.CargoCustomerID);
                });

            migrationBuilder.CreateTable(
                name: "CargoOperations",
                columns: table => new
                {
                    CargoOperationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoOperationBarcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOperationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOperationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoOperations", x => x.CargoOperationID);
                });

            migrationBuilder.CreateTable(
                name: "CargoDetails",
                columns: table => new
                {
                    CargoDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoDetailSenderCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoDetailReceiverCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoDetailBarcode = table.Column<int>(type: "int", nullable: false),
                    CargoCompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoDetails", x => x.CargoDetailID);
                    table.ForeignKey(
                        name: "FK_CargoDetails_CargoCompanies_CargoCompanyID",
                        column: x => x.CargoCompanyID,
                        principalTable: "CargoCompanies",
                        principalColumn: "CargoCompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_CargoCompanyID",
                table: "CargoDetails",
                column: "CargoCompanyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoCustomers");

            migrationBuilder.DropTable(
                name: "CargoDetails");

            migrationBuilder.DropTable(
                name: "CargoOperations");

            migrationBuilder.DropTable(
                name: "CargoCompanies");
        }
    }
}
