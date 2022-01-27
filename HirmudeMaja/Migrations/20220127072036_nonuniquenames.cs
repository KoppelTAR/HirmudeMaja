using Microsoft.EntityFrameworkCore.Migrations;

namespace HirmudeMaja.Migrations
{
    public partial class nonuniquenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seikleja_Eesnimi",
                table: "Seikleja");

            migrationBuilder.CreateIndex(
                name: "IX_Seikleja_Eesnimi",
                table: "Seikleja",
                column: "Eesnimi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seikleja_Eesnimi",
                table: "Seikleja");

            migrationBuilder.CreateIndex(
                name: "IX_Seikleja_Eesnimi",
                table: "Seikleja",
                column: "Eesnimi",
                unique: true);
        }
    }
}
