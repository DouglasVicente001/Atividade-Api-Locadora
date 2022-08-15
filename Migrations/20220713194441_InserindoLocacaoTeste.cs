using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAPI.Migrations
{
    public partial class InserindoLocacaoTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locacoes",
                columns: new[] { "Id", "ClienteId", "DataDevolucao", "DataLocacao", "EntregaEmAtraso", "FilmeId" },
                values: new object[] { 1, 1, new DateTime(2022, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 7, 13, 16, 44, 40, 583, DateTimeKind.Local).AddTicks(7660), false, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locacoes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
