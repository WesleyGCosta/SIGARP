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
                    CodigoAta = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Atas", x => new { x.CodigoAta, x.AnoAta });
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    CodigoItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAta = table.Column<int>(type: "int", nullable: false),
                    AnoAta = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(8000)", nullable: false),
                    Marca = table.Column<string>(type: "Varchar(50)", nullable: false),
                    UnidadeAquisicao = table.Column<string>(type: "Varchar(20)", nullable: false),
                    ConsumoEstimado = table.Column<int>(type: "int", nullable: false),
                    PrecoMercado = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PrecoRegistrado = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.CodigoItem);
                    table.ForeignKey(
                        name: "FK_Itens_Atas_CodigoAta_AnoAta",
                        columns: x => new { x.CodigoAta, x.AnoAta },
                        principalTable: "Atas",
                        principalColumns: new[] { "CodigoAta", "AnoAta" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detentoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(type: "Varchar(18)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "Varchar(100)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Telefone = table.Column<string>(type: "Varchar(15)", nullable: true),
                    Pessoa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Endereco = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Uf = table.Column<string>(type: "Varchar(5)", nullable: true),
                    Municipio = table.Column<string>(type: "Varchar(100)", nullable: true),
                    ItemCodigoItem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detentoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detentoras_Itens_ItemCodigoItem",
                        column: x => x.ItemCodigoItem,
                        principalTable: "Itens",
                        principalColumn: "CodigoItem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItensParticipantes",
                columns: table => new
                {
                    CodigoAta = table.Column<int>(type: "int", nullable: false),
                    AnoAta = table.Column<int>(type: "int", nullable: false),
                    CodigoItem = table.Column<int>(type: "int", nullable: false),
                    CodigoUnidadeAdministrativa = table.Column<int>(type: "int", nullable: false),
                    ItemCodigoItem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensParticipantes", x => new { x.CodigoAta, x.AnoAta });
                    table.ForeignKey(
                        name: "FK_ItensParticipantes_Itens_ItemCodigoItem",
                        column: x => x.ItemCodigoItem,
                        principalTable: "Itens",
                        principalColumn: "CodigoItem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgamacaoConsumoParticipoantes",
                columns: table => new
                {
                    CodigoAta = table.Column<int>(type: "int", nullable: false),
                    AnoAta = table.Column<int>(type: "int", nullable: false),
                    CodigoItem = table.Column<int>(type: "int", nullable: false),
                    CodigoUnidadeAdministrativa = table.Column<int>(type: "int", nullable: false),
                    ConsumoEstimado = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Aditivo = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Transferido = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    SaldoAnterior = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    ItemParticipanteCodigoAta = table.Column<int>(type: "int", nullable: true),
                    ItemParticipanteAnoAta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgamacaoConsumoParticipoantes", x => new { x.CodigoAta, x.AnoAta });
                    table.ForeignKey(
                        name: "FK_ProgamacaoConsumoParticipoantes_ItensParticipantes_ItemParticipanteCodigoAta_ItemParticipanteAnoAta",
                        columns: x => new { x.ItemParticipanteCodigoAta, x.ItemParticipanteAnoAta },
                        principalTable: "ItensParticipantes",
                        principalColumns: new[] { "CodigoAta", "AnoAta" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesAdministrativas",
                columns: table => new
                {
                    CodigoUnidadeAdministrativa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUnidadeAdministrativa = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Sigla = table.Column<string>(type: "Varchar(10)", nullable: false),
                    OrgaoEx = table.Column<bool>(type: "bit", nullable: false),
                    UnidadeDaFederacao = table.Column<string>(type: "Varchar(50)", nullable: false),
                    EsferaAdministrativa = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ItemParticipanteCodigoAta = table.Column<int>(type: "int", nullable: true),
                    ItemParticipanteAnoAta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesAdministrativas", x => x.CodigoUnidadeAdministrativa);
                    table.ForeignKey(
                        name: "FK_UnidadesAdministrativas_ItensParticipantes_ItemParticipanteCodigoAta_ItemParticipanteAnoAta",
                        columns: x => new { x.ItemParticipanteCodigoAta, x.ItemParticipanteAnoAta },
                        principalTable: "ItensParticipantes",
                        principalColumns: new[] { "CodigoAta", "AnoAta" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detentoras_ItemCodigoItem",
                table: "Detentoras",
                column: "ItemCodigoItem");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_CodigoAta_AnoAta",
                table: "Itens",
                columns: new[] { "CodigoAta", "AnoAta" });

            migrationBuilder.CreateIndex(
                name: "IX_ItensParticipantes_ItemCodigoItem",
                table: "ItensParticipantes",
                column: "ItemCodigoItem");

            migrationBuilder.CreateIndex(
                name: "IX_ProgamacaoConsumoParticipoantes_ItemParticipanteCodigoAta_ItemParticipanteAnoAta",
                table: "ProgamacaoConsumoParticipoantes",
                columns: new[] { "ItemParticipanteCodigoAta", "ItemParticipanteAnoAta" });

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesAdministrativas_ItemParticipanteCodigoAta_ItemParticipanteAnoAta",
                table: "UnidadesAdministrativas",
                columns: new[] { "ItemParticipanteCodigoAta", "ItemParticipanteAnoAta" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detentoras");

            migrationBuilder.DropTable(
                name: "ProgamacaoConsumoParticipoantes");

            migrationBuilder.DropTable(
                name: "UnidadesAdministrativas");

            migrationBuilder.DropTable(
                name: "ItensParticipantes");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Atas");
        }
    }
}
