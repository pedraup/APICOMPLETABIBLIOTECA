using ApiLivros.Models;

using Microsoft.EntityFrameworkCore;

public static class ROTA_DELETE
{
    public static void MapDeleteRoutes(this WebApplication app)
    {
        app.MapDelete("/api/livros/{id}", async (int id, LivrosContext db) =>
        {
            var livro = await db.Livros.FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
                return Results.NotFound("Livro não encontrado.");

            db.Livros.Remove(livro);
            await db.SaveChangesAsync();

            return Results.Ok("Livro excluído com sucesso.");
        });
    }
}