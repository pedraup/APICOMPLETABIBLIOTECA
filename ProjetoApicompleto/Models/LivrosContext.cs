using Microsoft.EntityFrameworkCore;

namespace ApiLivros.Models // ✅ necessário para funcionar com as migrations
{
    public class LivrosContext : DbContext
    {
        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
    }
}
