using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Infra.Migrations
{
    public partial class alterandoPropriedades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aditivo",
                table: "ProgamacaoConsumoParticipantes");

            migrationBuilder.AlterColumn<int>(
                name: "Transferido",
                table: "ProgamacaoConsumoParticipantes",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.AlterColumn<int>(
                name: "SaldoAnterior",
                table: "ProgamacaoConsumoParticipantes",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Saldo",
                table: "ProgamacaoConsumoParticipantes",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVencimentoAta",
                table: "Atas",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataVencimentoAta",
                table: "Atas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Transferido",
                table: "ProgamacaoConsumoParticipantes",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "SaldoAnterior",
                table: "ProgamacaoConsumoParticipantes",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "ProgamacaoConsumoParticipantes",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Aditivo",
                table: "ProgamacaoConsumoParticipantes",
                type: "decimal(15,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
