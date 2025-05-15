using Microsoft.EntityFrameworkCore.Migrations;
using ApiLivros.Models;


#nullable disable

namespace ApiLivros.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaModeloLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Livros",
                newName: "TituloLivro");

            migrationBuilder.RenameColumn(
                name: "Autor",
                table: "Livros",
                newName: "AutorLivro");

            migrationBuilder.RenameColumn(
                name: "AnoPublicacao",
                table: "Livros",
                newName: "Ano");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TituloLivro",
                table: "Livros",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "AutorLivro",
                table: "Livros",
                newName: "Autor");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "Livros",
                newName: "AnoPublicacao");
        }
    }
}
