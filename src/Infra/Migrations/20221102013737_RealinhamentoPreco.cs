using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class RealinhamentoPreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealinhamentosPrecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "date", nullable: false),
                    PrecoMercado = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PrecoRegistrado = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    PrecoAtual = table.Column<bool>(type: "bit", nullable: false),
                    Justificativa = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealinhamentosPrecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealinhamentosPrecos_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealinhamentosPrecos_ItemId",
                table: "RealinhamentosPrecos",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealinhamentosPrecos");
        }
    }
}
