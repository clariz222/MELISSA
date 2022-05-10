using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MELISSA.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameofProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mel", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mel");
        }
    }
}
