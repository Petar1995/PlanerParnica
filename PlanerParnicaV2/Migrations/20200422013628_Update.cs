using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanerParnicaV2.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parnice_Lokacije_LokacijaOdrzvanjaId",
                table: "Parnice");

            migrationBuilder.RenameColumn(
                name: "LokacijaOdrzvanjaId",
                table: "Parnice",
                newName: "LokacijaOdrzavanjaId");

            migrationBuilder.RenameIndex(
                name: "IX_Parnice_LokacijaOdrzvanjaId",
                table: "Parnice",
                newName: "IX_Parnice_LokacijaOdrzavanjaId");

            migrationBuilder.AlterColumn<string>(
                name: "BrojSudnice",
                table: "Parnice",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddForeignKey(
                name: "FK_Parnice_Lokacije_LokacijaOdrzavanjaId",
                table: "Parnice",
                column: "LokacijaOdrzavanjaId",
                principalTable: "Lokacije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parnice_Lokacije_LokacijaOdrzavanjaId",
                table: "Parnice");

            migrationBuilder.RenameColumn(
                name: "LokacijaOdrzavanjaId",
                table: "Parnice",
                newName: "LokacijaOdrzvanjaId");

            migrationBuilder.RenameIndex(
                name: "IX_Parnice_LokacijaOdrzavanjaId",
                table: "Parnice",
                newName: "IX_Parnice_LokacijaOdrzvanjaId");

            migrationBuilder.AlterColumn<int>(
                name: "BrojSudnice",
                table: "Parnice",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Parnice_Lokacije_LokacijaOdrzvanjaId",
                table: "Parnice",
                column: "LokacijaOdrzvanjaId",
                principalTable: "Lokacije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
