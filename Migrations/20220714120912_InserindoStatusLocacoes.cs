using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAPI.Migrations
{
    public partial class InserindoStatusLocacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locacoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Locacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Locacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Locacoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_ClienteId",
                table: "Locacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_FilmeId",
                table: "Locacoes",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Clientes_ClienteId",
                table: "Locacoes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Filmes_FilmeId",
                table: "Locacoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Clientes_ClienteId",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Filmes_FilmeId",
                table: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Locacoes_ClienteId",
                table: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Locacoes_FilmeId",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Locacoes");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Locacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Locacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Locacoes",
                columns: new[] { "Id", "ClienteId", "DataDevolucao", "DataLocacao", "EntregaEmAtraso", "FilmeId" },
                values: new object[] { 1, 1, new DateTime(2022, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 7, 13, 16, 44, 40, 583, DateTimeKind.Local).AddTicks(7660), false, 1 });
        }
    }
}
