using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class newProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecoMercadoAnterior",
                table: "RealinhamentosPrecos",
                type: "decimal(15,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoRegistradoAnterior",
                table: "RealinhamentosPrecos",
                type: "decimal(15,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoMercadoAnterior",
                table: "RealinhamentosPrecos");

            migrationBuilder.DropColumn(
                name: "PrecoRegistradoAnterior",
                table: "RealinhamentosPrecos");
        }
    }
}
