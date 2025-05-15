using Microsoft.EntityFrameworkCore.Migrations;
using ApiLivros.Models;


#nullable disable

namespace ApiLivros.Migrations
{
    /// <inheritdoc />
    public partial class CriarBancoComCamposCompletos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Citacao",
                table: "Livros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoMaterial",
                table: "Livros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Citacao",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "TipoMaterial",
                table: "Livros");
        }
    }
}
