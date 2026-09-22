using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POC_Afastamentos_V2.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoValicaoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Afastamentos_Policial_PolicialRe",
                table: "Solicitacao_Afastamentos");

            migrationBuilder.RenameColumn(
                name: "PolicialRe",
                table: "Solicitacao_Afastamentos",
                newName: "SolicitanteRe");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitacao_Afastamentos_PolicialRe",
                table: "Solicitacao_Afastamentos",
                newName: "IX_Solicitacao_Afastamentos_SolicitanteRe");

            migrationBuilder.AddColumn<string>(
                name: "InteressadoRe",
                table: "Solicitacao_Afastamentos",
                type: "nvarchar(6)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Policial",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_Afastamentos_InteressadoRe",
                table: "Solicitacao_Afastamentos",
                column: "InteressadoRe");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Afastamentos_Policial_InteressadoRe",
                table: "Solicitacao_Afastamentos",
                column: "InteressadoRe",
                principalTable: "Policial",
                principalColumn: "Re",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Afastamentos_Policial_SolicitanteRe",
                table: "Solicitacao_Afastamentos",
                column: "SolicitanteRe",
                principalTable: "Policial",
                principalColumn: "Re",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Afastamentos_Policial_InteressadoRe",
                table: "Solicitacao_Afastamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Afastamentos_Policial_SolicitanteRe",
                table: "Solicitacao_Afastamentos");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_Afastamentos_InteressadoRe",
                table: "Solicitacao_Afastamentos");

            migrationBuilder.DropColumn(
                name: "InteressadoRe",
                table: "Solicitacao_Afastamentos");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Policial");

            migrationBuilder.RenameColumn(
                name: "SolicitanteRe",
                table: "Solicitacao_Afastamentos",
                newName: "PolicialRe");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitacao_Afastamentos_SolicitanteRe",
                table: "Solicitacao_Afastamentos",
                newName: "IX_Solicitacao_Afastamentos_PolicialRe");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Afastamentos_Policial_PolicialRe",
                table: "Solicitacao_Afastamentos",
                column: "PolicialRe",
                principalTable: "Policial",
                principalColumn: "Re",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
