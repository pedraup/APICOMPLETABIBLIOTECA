using ApiLivros.Models;

using Microsoft.EntityFrameworkCore;

public static class ROTA_GET
{
    public static void MapGetRoutes(this WebApplication app)
    {
        app.MapGet("/", () => "API da Biblioteca em funcionamento!");

        // Buscar todos os livros do banco
        app.MapGet("/api/livros", async (LivrosContext db) =>
            await db.Livros.ToListAsync());

        // Buscar livro por ID
        app.MapGet("/api/livros/{id}", async (int id, LivrosContext db) =>
        {
            var livro = await db.Livros.FirstOrDefaultAsync(l => l.Id == id);
            return livro != null ? Results.Ok(livro) : Results.NotFound("Livro não encontrado.");
        });
    }
}