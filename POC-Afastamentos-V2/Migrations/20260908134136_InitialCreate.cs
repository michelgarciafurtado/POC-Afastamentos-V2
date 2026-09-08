using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POC_Afastamentos_V2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afastamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afastamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opm",
                columns: table => new
                {
                    OpmCod = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NomeOpm = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OpmNivel = table.Column<int>(type: "int", nullable: false),
                    LocalOpm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opm", x => x.OpmCod);
                });

            migrationBuilder.CreateTable(
                name: "Posto_Graducao",
                columns: table => new
                {
                    PosCod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PosNivel = table.Column<int>(type: "int", nullable: false),
                    PosAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posto_Graducao", x => x.PosCod);
                });

            migrationBuilder.CreateTable(
                name: "Policial",
                columns: table => new
                {
                    Re = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Dg = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PosCod = table.Column<int>(type: "int", nullable: false),
                    OpmCod = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policial", x => x.Re);
                    table.ForeignKey(
                        name: "FK_Policial_Opm_OpmCod",
                        column: x => x.OpmCod,
                        principalTable: "Opm",
                        principalColumn: "OpmCod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policial_Posto_Graducao_PosCod",
                        column: x => x.PosCod,
                        principalTable: "Posto_Graducao",
                        principalColumn: "PosCod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacao_Afastamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicialRe = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    OpmCod = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroDias = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoAfastamentoId = table.Column<int>(type: "int", nullable: false),
                    DetalhesAfastamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao_Afastamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacao_Afastamentos_Afastamento_TipoAfastamentoId",
                        column: x => x.TipoAfastamentoId,
                        principalTable: "Afastamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitacao_Afastamentos_Opm_OpmCod",
                        column: x => x.OpmCod,
                        principalTable: "Opm",
                        principalColumn: "OpmCod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitacao_Afastamentos_Policial_PolicialRe",
                        column: x => x.PolicialRe,
                        principalTable: "Policial",
                        principalColumn: "Re",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policial_OpmCod",
                table: "Policial",
                column: "OpmCod");

            migrationBuilder.CreateIndex(
                name: "IX_Policial_PosCod",
                table: "Policial",
                column: "PosCod");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_Afastamentos_OpmCod",
                table: "Solicitacao_Afastamentos",
                column: "OpmCod");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_Afastamentos_PolicialRe",
                table: "Solicitacao_Afastamentos",
                column: "PolicialRe");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_Afastamentos_TipoAfastamentoId",
                table: "Solicitacao_Afastamentos",
                column: "TipoAfastamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitacao_Afastamentos");

            migrationBuilder.DropTable(
                name: "Afastamento");

            migrationBuilder.DropTable(
                name: "Policial");

            migrationBuilder.DropTable(
                name: "Opm");

            migrationBuilder.DropTable(
                name: "Posto_Graducao");
        }
    }
}
