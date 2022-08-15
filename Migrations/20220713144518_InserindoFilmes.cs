using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAPI.Migrations
{
    public partial class InserindoFilmes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Filmes",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Filmes",
                newName: "Genero");

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Disponivel", "Genero", "Status", "Titulo" },
                values: new object[,]
                {
                    { 1, true, "Guerra", true, "O Resgate do Soldado Ryan" },
                    { 2, true, "Drama", true, "Titanic" },
                    { 3, true, "Comédia", true, "Gente Grande" },
                    { 4, true, "Terror", true, "A Bruxa de Blair" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Filmes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Filmes",
                newName: "Categoria");
        }
    }
}
