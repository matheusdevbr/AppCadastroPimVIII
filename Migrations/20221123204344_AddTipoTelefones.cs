using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCadastro.Migrations
{
    public partial class AddTipoTelefones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoTelefone_Telefones_TelefoneId",
                table: "TipoTelefone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoTelefone",
                table: "TipoTelefone");

            migrationBuilder.RenameTable(
                name: "TipoTelefone",
                newName: "TipoTelefones");

            migrationBuilder.RenameIndex(
                name: "IX_TipoTelefone_TelefoneId",
                table: "TipoTelefones",
                newName: "IX_TipoTelefones_TelefoneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoTelefones",
                table: "TipoTelefones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoTelefones_Telefones_TelefoneId",
                table: "TipoTelefones",
                column: "TelefoneId",
                principalTable: "Telefones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoTelefones_Telefones_TelefoneId",
                table: "TipoTelefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoTelefones",
                table: "TipoTelefones");

            migrationBuilder.RenameTable(
                name: "TipoTelefones",
                newName: "TipoTelefone");

            migrationBuilder.RenameIndex(
                name: "IX_TipoTelefones_TelefoneId",
                table: "TipoTelefone",
                newName: "IX_TipoTelefone_TelefoneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoTelefone",
                table: "TipoTelefone",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoTelefone_Telefones_TelefoneId",
                table: "TipoTelefone",
                column: "TelefoneId",
                principalTable: "Telefones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
