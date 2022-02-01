using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HirmudeMaja.Migrations
{
    public partial class AddVahemik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Vahemik",
                table: "Seikleja",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vahemik",
                table: "Seikleja");
        }
    }
}
