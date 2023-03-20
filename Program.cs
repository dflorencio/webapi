using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/", () => new {
        Nome = "Davi FLorencio;",
        Idade = 31
});

app.MapGet("/AddHeader", (HttpResponse response) => {
    response.Headers.Add("Teste", "Davi Florencio");
    return new {
        Nome = "Davi FLorencio",
        Idade = 31
        };
    });



app.MapPost("/produto", (Produto produto) => {
    ProdutoRepositorio.Add(produto);
    return Results.Created("/produto/" + produto.Codigo, produto.Codigo);
});


app.MapGet("/produto/{codigo}", ([FromRoute]string codigo) => {
    var produto = ProdutoRepositorio.GetBy(codigo);
    if(produto != null)
        return Results.Ok(produto);
    return Results.NotFound();
});


app.MapPut("/produto", (Produto produto) =>{
    var produtoSalvo = ProdutoRepositorio.GetBy(produto.Codigo);
    produtoSalvo.Nome = produto.Nome;
    return Results.Ok();
});


app.MapDelete("/produto/{codigo}", ([FromRoute]string codigo) =>{
    var produto = ProdutoRepositorio.GetBy(codigo);
    ProdutoRepositorio.Remove(produto);
    return Results.Ok();
});
// Via parametro 
app.MapGet("/produto" , ([FromQuery]string dataInicial, [FromQuery]string dataFinal) => {
    return dataInicial + " - " + dataFinal;    
    });




   
app.MapGet("/getproduto",(HttpRequest request) => {
    return request.Headers["produto-codigo"].ToString();
});


app.Run();




public class Produto {
    public string Codigo { get; set; }
    public string  Nome { get; set; }
}





 public static class ProdutoRepositorio {
    public static List<Produto> Produtos { get; set; }

    public static  void Add(Produto produto) {
        if(Produtos == null)
            Produtos = new List<Produto>();

        Produtos.Add(produto);    
    }

    public static Produto GetBy(string codigo) {
        return Produtos.FirstOrDefault(p =>p.Codigo ==codigo);
    }
    public static void Remove(Produto produto){
        Produtos.Remove(produto);
    }
 }