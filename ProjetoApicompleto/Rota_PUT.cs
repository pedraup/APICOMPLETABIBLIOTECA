using ApiLivros.Models;

using Microsoft.EntityFrameworkCore;

public static class ROTA_PUT
{
    public static void MapPutRoutes(this WebApplication app)
    {
        app.MapPut("/api/livros/{id}", async (int id, Livro livroAtualizado, LivrosContext db) =>
        {
            var livro = await db.Livros.FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
                return Results.NotFound("Livro não encontrado.");

            livro.TituloLivro = livroAtualizado.TituloLivro;
            livro.AutorLivro = livroAtualizado.AutorLivro;
            livro.Ano = livroAtualizado.Ano;
            livro.TipoMaterial = livroAtualizado.TipoMaterial;
            livro.Citacao = livroAtualizado.Citacao;

            await db.SaveChangesAsync();

            return Results.Ok(livro);
        });
    }
}
