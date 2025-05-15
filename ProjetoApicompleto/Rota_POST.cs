
using ApiLivros.Models;
public static class ROTA_POST
{
    public static void MapPostRoutes(this WebApplication app)
    {
        app.MapPost("/api/livros", async (Livro novoLivro, LivrosContext db) =>
        {
            db.Livros.Add(novoLivro);
            await db.SaveChangesAsync();
            return Results.Created($"/api/livros/{novoLivro.Id}", novoLivro);
        });
    }
}
