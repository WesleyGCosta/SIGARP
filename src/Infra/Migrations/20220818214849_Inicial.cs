using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class Inicial : Migration
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
                    TipoPregao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataHomologacao = table.Column<DateTime>(type: "date", nullable: false),
                    DataPublicacaoDOE = table.Column<DateTime>(type: "date", nullable: false),
                    DataFinalVigencia = table.Column<DateTime>(type: "date", nullable: false),
                    ObjetoResumido = table.Column<string>(type: "text", nullable: true),
                    Publicada = table.Column<bool>(type: "bit", nullable: false),
                    DataPublicacaoSistema = table.Column<DateTime>(type: "date", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "date", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "date", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    LimiteAdesao = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atas", x => new { x.CodigoAta, x.AnoAta });
                });

            migrationBuilder.CreateTable(
                name: "Detentoras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(type: "Varchar(18)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "Varchar(100)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Telefone = table.Column<string>(type: "Varchar(15)", nullable: true),
                    Pessoa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detentoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesAdministrativas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeUnidadeAdministrativa = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Sigla = table.Column<string>(type: "Varchar(10)", nullable: false),
                    OrgaoEx = table.Column<bool>(type: "bit", nullable: false),
                    UnidadeDaFederacao = table.Column<string>(type: "Varchar(50)", nullable: false),
                    EsferaAdministrativa = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesAdministrativas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroItem = table.Column<int>(type: "int", nullable: false),
                    CodigoAta = table.Column<int>(type: "int", nullable: false),
                    AnoAta = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(8000)", nullable: false),
                    Marca = table.Column<string>(type: "Varchar(50)", nullable: false),
                    UnidadeAquisicao = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoMercado = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PrecoRegistrado = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_Atas_CodigoAta_AnoAta",
                        columns: x => new { x.CodigoAta, x.AnoAta },
                        principalTable: "Atas",
                        principalColumns: new[] { "CodigoAta", "AnoAta" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DetentoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "Varchar(10)", nullable: false),
                    Rua = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Uf = table.Column<string>(type: "Varchar(5)", nullable: false),
                    Municipio = table.Column<string>(type: "Varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Detentoras_DetentoraId",
                        column: x => x.DetentoraId,
                        principalTable: "Detentoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetentorasItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DetentoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetentorasItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetentorasItens_Detentoras_DetentoraId",
                        column: x => x.DetentoraId,
                        principalTable: "Detentoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetentorasItens_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantesItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnidadeAdministrativaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantesItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantesItens_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantesItens_UnidadesAdministrativas_UnidadeAdministrativaId",
                        column: x => x.UnidadeAdministrativaId,
                        principalTable: "UnidadesAdministrativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgamacaoConsumoParticipantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumoEstimado = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Aditivo = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Transferido = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    SaldoAnterior = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgamacaoConsumoParticipantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgamacaoConsumoParticipantes_ParticipantesItens_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "ParticipantesItens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetentorasItens_DetentoraId",
                table: "DetentorasItens",
                column: "DetentoraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetentorasItens_ItemId",
                table: "DetentorasItens",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_DetentoraId",
                table: "Enderecos",
                column: "DetentoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_CodigoAta_AnoAta",
                table: "Itens",
                columns: new[] { "CodigoAta", "AnoAta" });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesItens_ItemId",
                table: "ParticipantesItens",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesItens_UnidadeAdministrativaId",
                table: "ParticipantesItens",
                column: "UnidadeAdministrativaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgamacaoConsumoParticipantes_ParticipanteId",
                table: "ProgamacaoConsumoParticipantes",
                column: "ParticipanteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetentorasItens");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "ProgamacaoConsumoParticipantes");

            migrationBuilder.DropTable(
                name: "Detentoras");

            migrationBuilder.DropTable(
                name: "ParticipantesItens");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "UnidadesAdministrativas");

            migrationBuilder.DropTable(
                name: "Atas");
        }
    }
}
