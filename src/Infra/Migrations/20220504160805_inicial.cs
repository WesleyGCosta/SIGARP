using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atas",
                columns: table => new
                {
                    NumeroAta = table.Column<int>(type: "int", nullable: false),
                    AnoAta = table.Column<int>(type: "int", nullable: false),
                    NumeroProcesso = table.Column<string>(type: "varchar(25)", nullable: false),
                    NumeroPregao = table.Column<string>(type: "varchar(25)", nullable: false),
                    AnoPregao = table.Column<int>(type: "int", nullable: false),
                    DataHomologacao = table.Column<DateTime>(type: "date", nullable: false),
                    DataPublicacaoDOE = table.Column<DateTime>(type: "date", nullable: false),
                    DataFinalVigencia = table.Column<DateTime>(type: "date", nullable: false),
                    ObjetoResumido = table.Column<string>(type: "text", nullable: false),
                    Publicada = table.Column<bool>(type: "bit", nullable: false),
                    DataPublicacaoSistema = table.Column<DateTime>(type: "date", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: false),
                    LimiteAdesao = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atas", x => new { x.NumeroAta, x.AnoAta });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atas");
        }
    }
}
