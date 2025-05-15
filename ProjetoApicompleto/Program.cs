using Microsoft.EntityFrameworkCore;
using ApiLivros.Models; // necessário para reconhecer Livro e LivrosContext

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Configuração do banco de dados SQLite
builder.Services.AddDbContext<LivrosContext>(options =>
    options.UseSqlite("Data Source=livros.db"));

var app = builder.Build();

// Ativa o CORS
app.UseCors("AllowAll");

// Suas rotas (preservadas)
app.MapGetRoutes();
app.MapPostRoutes();
app.MapPutRoutes();
app.MapDeleteRoutes();

// Popular banco de dados com 20 livros se estiver vazio
void PopularBancoDeDados(IApplicationBuilder app)
{
    using var scope = app.ApplicationServices.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<LivrosContext>();

    context.Database.Migrate(); // Aplica migrations automaticamente

    if (!context.Livros.Any())
    {
       var livrosIniciais = new List<Livro>
{
    new() { Id = 1, TituloLivro = "Perceived Challenges And Opportunities Arising From Integration Of Mental Health Into Primary Care", AutorLivro = "Abera, M. et al.", Ano = 2014, TipoMaterial = "Artigo científico", Citacao = "Abera et al. (2014)" },
    new() { Id = 2, TituloLivro = "Estado formaliza ampliação de plataforma para integração e gestão de dados do SUS", AutorLivro = "Abrantes, G. et al.", Ano = 2024, TipoMaterial = "Notícia institucional", Citacao = "Abrantes et al. (2024)" },
    new() { Id = 3, TituloLivro = "European Open Science Cloud: um novo desafio para a Europa", AutorLivro = "Almeida, A. V. D. et al.", Ano = 2017, TipoMaterial = "Artigo científico", Citacao = "Almeida et al. (2017)" },
    new() { Id = 4, TituloLivro = "Informação Como Apoio Para Tomada De Decisão De Gestores Públicos De Saúde", AutorLivro = "Antunes, F. M. et al.", Ano = 2021, TipoMaterial = "Artigo científico", Citacao = "Antunes et al. (2021)" },
    new() { Id = 5, TituloLivro = "Perfil Clínico E Sociodemográfico De Adolescentes Em CAPSAD", AutorLivro = "Araujo, N. B. et al.", Ano = 2012, TipoMaterial = "Artigo científico", Citacao = "Araujo et al. (2012)" },
    new() { Id = 6, TituloLivro = "Open source pharma and its developmental potential", AutorLivro = "Arza, V.; Sebastian, S.", Ano = 2018, TipoMaterial = "Artigo científico", Citacao = "Arza & Sebastian (2018)" },
    new() { Id = 7, TituloLivro = "Pesquisa em Educação em Ciências", AutorLivro = "Azevedo, N. H.; Mendonça, P. C. C.", Ano = 2024, TipoMaterial = "Capítulo de livro", Citacao = "Azevedo & Mendonça (2024)" },
    new() { Id = 8, TituloLivro = "Contribuição À Discussão Sobre A Legalização De Drogas", AutorLivro = "Bessa, Marco Antonio", Ano = 2010, TipoMaterial = "Artigo de opinião", Citacao = "Bessa (2010)" },
    new() { Id = 9, TituloLivro = "Sistema De Informação Da Atenção Básica Como Ferramenta Da Gestão Em Saúde", AutorLivro = "Bittar, T. O. et al.", Ano = 2009, TipoMaterial = "Artigo científico", Citacao = "Bittar et al. (2009)" },
    new() { Id = 10, TituloLivro = "A gestão da informação como ferramenta estratégica para a saúde", AutorLivro = "Borges, L. M.", Ano = 2014, TipoMaterial = "Artigo científico", Citacao = "Borges (2014)" },
    new() { Id = 11, TituloLivro = "Cadastro Nacional de Estabelecimentos de Saúde – CNES", AutorLivro = "Ministério da Saúde", Ano = 2025, TipoMaterial = "Fonte governamental", Citacao = "Brasil (2025)" },
    new() { Id = 12, TituloLivro = "Plano Diretor de Tecnologia da Informação e Comunicação", AutorLivro = "Ministério da Saúde", Ano = 2022, TipoMaterial = "Documento técnico", Citacao = "Brasil (2022)" },
    new() { Id = 13, TituloLivro = "Vermont Hub-And-Spoke Model Of Care For Opioid Use Disorder", AutorLivro = "Brooklyn, J. R.; Sigmon, S. C.", Ano = 2017, TipoMaterial = "Relato de experiência", Citacao = "Brooklyn & Sigmon (2017)" },
    new() { Id = 14, TituloLivro = "Determinantes da lealdade no mercado de serviços de saúde domiciliar", AutorLivro = "Buarque, L.; Mesquita, J.", Ano = 2015, TipoMaterial = "Artigo científico", Citacao = "Buarque & Mesquita (2015)" },
    new() { Id = 15, TituloLivro = "Open Data In Health: Case Studies From The Field", AutorLivro = "Davies, J. et al.", Ano = 2019, TipoMaterial = "Artigo técnico", Citacao = "Davies et al. (2019)" },
    new() { Id = 16, TituloLivro = "Drug Abuse In Adolescence: Neurobiological, Cognitive, And Psychological Issues", AutorLivro = "Souza-Formigoni, M. L. O. (Org.)", Ano = 2016, TipoMaterial = "Livro científico", Citacao = "Souza-Formigoni (2016)" },
    new() { Id = 17, TituloLivro = "Relato De Experiência De Um Atendimento De Saúde Mental Em Uma UPA", AutorLivro = "Pereira, S. et al.", Ano = 2020, TipoMaterial = "Relato de caso", Citacao = "Pereira et al. (2020)" },
    new() { Id = 18, TituloLivro = "O Conceito Eficiência Na Gestão Da Saúde Pública Brasileira", AutorLivro = "Dermindo, M. P. et al.", Ano = 2020, TipoMaterial = "Artigo científico", Citacao = "Dermindo et al. (2020)" },
    new() { Id = 19, TituloLivro = "Cuidando De Pacientes Com Transtornos Por Uso De Opioides No Hospital", AutorLivro = "Donroe, J. H. et al.", Ano = 2016, TipoMaterial = "Artigo científico", Citacao = "Donroe et al. (2016)" },
    new() { Id = 20, TituloLivro = "Caring For Patients With Opioid Use Disorder In The Hospital", AutorLivro = "Donroe, J. H. et al.", Ano = 2016, TipoMaterial = "Artigo científico", Citacao = "Donroe et al. (2016)" }
};
        context.Livros.AddRange(livrosIniciais);
        context.SaveChanges();
    }
}

// Executa o seed ao iniciar
PopularBancoDeDados(app);

app.Run();
