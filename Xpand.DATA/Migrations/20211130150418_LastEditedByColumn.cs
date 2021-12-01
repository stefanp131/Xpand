using Microsoft.EntityFrameworkCore.Migrations;

namespace Xpand.DATA.Migrations
{
    public partial class LastEditedByColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastEditedBy",
                table: "Planets",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastEditedBy",
                table: "Planets");
        }
    }
}
