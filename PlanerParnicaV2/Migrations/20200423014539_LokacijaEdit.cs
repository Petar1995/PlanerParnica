using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanerParnicaV2.Migrations
{
    public partial class LokacijaEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Naslov",
                table: "Lokacije",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Naslov",
                table: "Lokacije",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
