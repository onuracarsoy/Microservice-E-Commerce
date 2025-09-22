using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Review.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentNameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentRate = table.Column<int>(type: "int", nullable: false),
                    CommentCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
