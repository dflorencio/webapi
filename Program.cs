using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<AplicacaoDBContext>(builder.Configuration["ConnectionStrings:host"]);


var app = builder.Build();
var configuration = app.Configuration;
ProdutoRepositorio.Init(configuration);







app.MapPost("/produto", (ProdutoRequest produtoRequest, AplicacaoDBContext context) =>
{
    var categoria = context.Categorias.Where(c => c.ID == produtoRequest.CategoriaId).First();
    var produto = new Produto
    {
        Codigo = produtoRequest.Codigo,
        Nome = produtoRequest.Nome,
        Descricao = produtoRequest.Descricao,
        Categoria = categoria
    };

    if (produtoRequest.Tags != null)
    {
        produto.Tags = new List<Tag>();
        foreach (var item in produtoRequest.Tags)
        {
            produto.Tags.Add(new Tag { Nome = item });
        }
    }
    context.Produtos.Add(produto);
    context.SaveChanges();
    return Results.Created($"/produto/ + {produto.Id}", produto.Id);
});


app.MapGet("/produto/{id}", ([FromRoute] int id, AplicacaoDBContext context) =>
{
    var produto = context.Produtos
    .Include(p => p.Categoria)
    .Include(p => p.Tags)
    .Where(p => p.Id == id).First();

    if (produto != null)
        return Results.Ok(produto);
    return Results.NotFound();
});

app.MapGet("/produto/", (AplicacaoDBContext context) =>
{
    var produtos = context.Produtos.ToList();

    if (produtos != null)
        return Results.Ok(produtos);
    return Results.NotFound();
});

app.MapPut("/produto/{id}", ([FromRoute] int id, ProdutoRequest produtoReqest, AplicacaoDBContext context) =>
{
    var produto = context.Produtos
    .Include(p => p.Tags)
    .Where(p => p.Id == id).First();
    var categoria = context.Categorias.Where(c => c.ID == produtoReqest.CategoriaId).First();

    produto.Codigo = produtoReqest.Codigo;
    produto.Nome = produtoReqest.Nome;
    produto.Descricao = produtoReqest.Descricao;
    produto.Categoria = categoria;
    produto.Tags = new List<Tag>();
    if (produtoReqest.Tags != null)
        foreach (var item in produtoReqest.Tags)
        {
            produto.Tags.Add(new Tag { Nome = item });
        }
    context.SaveChanges();
    return Results.Ok();
});

app.MapDelete("/produto/{id}", ([FromRoute] int id, AplicacaoDBContext context) =>
{
    var produto = context.Produtos.Where(p => p.Id == id).First();
    context.Produtos.Remove(produto);
    context.SaveChanges();
    return Results.Ok();
});
// Via parametro 

app.Run();
