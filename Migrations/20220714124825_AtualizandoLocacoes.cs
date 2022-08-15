using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAPI.Migrations
{
    public partial class AtualizandoLocacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntregaEmAtraso",
                table: "Locacoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EntregaEmAtraso",
                table: "Locacoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
