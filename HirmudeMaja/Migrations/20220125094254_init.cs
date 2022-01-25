using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HirmudeMaja.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seikleja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eesnimi = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Sisenemisaeg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Väljumisaeg = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seikleja", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seikleja_Eesnimi",
                table: "Seikleja",
                column: "Eesnimi",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seikleja");
        }
    }
}
