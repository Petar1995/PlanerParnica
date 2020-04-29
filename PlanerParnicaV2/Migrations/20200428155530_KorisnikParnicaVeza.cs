using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanerParnicaV2.Migrations
{
    public partial class KorisnikParnicaVeza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Parnice_ParnicaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ParnicaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ParnicaId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "KorisnikParnica",
                columns: table => new
                {
                    KorisnikId = table.Column<string>(nullable: false),
                    ParnicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikParnica", x => new { x.KorisnikId, x.ParnicaId });
                    table.ForeignKey(
                        name: "FK_KorisnikParnica_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikParnica_Parnice_ParnicaId",
                        column: x => x.ParnicaId,
                        principalTable: "Parnice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikParnica_ParnicaId",
                table: "KorisnikParnica",
                column: "ParnicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikParnica");

            migrationBuilder.AddColumn<int>(
                name: "ParnicaId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ParnicaId",
                table: "AspNetUsers",
                column: "ParnicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Parnice_ParnicaId",
                table: "AspNetUsers",
                column: "ParnicaId",
                principalTable: "Parnice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
