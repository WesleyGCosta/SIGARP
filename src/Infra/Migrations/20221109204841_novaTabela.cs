using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class novaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdemFornecimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramacaoConsumoParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFornecimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroProcesso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consumo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemFornecimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemFornecimento_ProgamacaoConsumoParticipantes_ProgramacaoConsumoParticipanteId",
                        column: x => x.ProgramacaoConsumoParticipanteId,
                        principalTable: "ProgamacaoConsumoParticipantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemFornecimento_ProgramacaoConsumoParticipanteId",
                table: "OrdemFornecimento",
                column: "ProgramacaoConsumoParticipanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemFornecimento");
        }
    }
}
