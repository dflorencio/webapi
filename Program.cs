using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<AplicacaoDBContext>(builder.Configuration["ConnectionStrings:host"]);


var app = builder.Build();
var configuration = app.Configuration;
ProdutoRepositorio.Init(configuration);


app.MapGet("/", () => "Hello World!");

app.MapPost("/", () => new
{
    Nome = "Davi FLorencio;",
    Idade = 31
});

app.MapGet("/AddHeader", (HttpResponse response) =>
{
    response.Headers.Add("Teste", "Davi Florencio");
    return new
    {
        Nome = "Davi FLorencio",
        Idade = 31
    };
});

/*app.MapPost("/produto", (ProdutoRequest produtoRequest, AplicacaoDbContext context) =>
{
    /* var categoria = context.Categoria.Where(c => c.ID == produtoRequest.CategoriaId).First();
     var produto = new Produto
     {
         Codigo = produtoRequest.Codigo,
         Nome = produtoRequest.Nome,
         Descricao = produtoRequest.Descricao,
         Categoria = categoria
     };
     context.Produtos.Add(produto);
     return Results.Created($"/produto/ + {produto.Id}", produto.Id);
});
*/

app.MapGet("/produto/{codigo}", ([FromRoute] string codigo) =>
{
    var produto = ProdutoRepositorio.GetBy(codigo);
    if (produto != null)
        return Results.Ok(produto);
    return Results.NotFound();
});

app.MapPut("/produto", (Produto produto) =>
{
    var produtoSalvo = ProdutoRepositorio.GetBy(produto.Codigo);
    produtoSalvo.Nome = produto.Nome;
    return Results.Ok();
});


app.MapDelete("/produto/{codigo}", ([FromRoute] string codigo) =>
{
    var produto = ProdutoRepositorio.GetBy(codigo);
    ProdutoRepositorio.Remove(produto);
    return Results.Ok();
});
// Via parametro 
app.MapGet("/produto", ([FromQuery] string dataInicial, [FromQuery] string dataFinal) =>
{
    return dataInicial + " - " + dataFinal;
});

app.MapGet("/getproduto", (HttpRequest request) =>
{
    return request.Headers["produto-codigo"].ToString();
});

if (app.Environment.IsStaging())
{
    app.MapGet("/configuration/database", (IConfiguration configuration) =>
    {
        return Results.Ok($"{configuration["database:Connection"]} / {configuration["database:port"]}");
    });
};
app.Run();
