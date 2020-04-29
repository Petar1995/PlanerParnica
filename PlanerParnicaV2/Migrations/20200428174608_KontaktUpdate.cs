using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanerParnicaV2.Migrations
{
    public partial class KontaktUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipLica",
                table: "Kontakti",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipLica",
                table: "Kontakti");
        }
    }
}
