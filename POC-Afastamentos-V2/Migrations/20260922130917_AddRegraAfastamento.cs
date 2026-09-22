using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POC_Afastamentos_V2.Migrations
{
    /// <inheritdoc />
    public partial class AddRegraAfastamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegrasAfastamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAfastamentoId = table.Column<int>(type: "int", nullable: false),
                    TipoRegra = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequencia = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DiasMinimo = table.Column<int>(type: "int", nullable: false),
                    DiasMaximo = table.Column<int>(type: "int", nullable: false),
                    qtd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegrasAfastamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegrasAfastamentos_Afastamento_TipoAfastamentoId",
                        column: x => x.TipoAfastamentoId,
                        principalTable: "Afastamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegrasAfastamentos_TipoAfastamentoId",
                table: "RegrasAfastamentos",
                column: "TipoAfastamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegrasAfastamentos");
        }
    }
}
