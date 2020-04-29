using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanerParnicaV2.Migrations
{
    public partial class KompanijaEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontakti_Kontakti_PripadnostKompanijiId",
                table: "Kontakti");

            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Kontakti");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Kontakti");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Kontakti");

            migrationBuilder.CreateTable(
                name: "Kompanije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompanije", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Kontakti_Kompanije_PripadnostKompanijiId",
                table: "Kontakti",
                column: "PripadnostKompanijiId",
                principalTable: "Kompanije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontakti_Kompanije_PripadnostKompanijiId",
                table: "Kontakti");

            migrationBuilder.DropTable(
                name: "Kompanije");

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Kontakti",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Kontakti",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Kontakti",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Kontakti_Kontakti_PripadnostKompanijiId",
                table: "Kontakti",
                column: "PripadnostKompanijiId",
                principalTable: "Kontakti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
