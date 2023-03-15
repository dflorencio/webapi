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
});



// Via parametro 
app.MapGet("/produto" , ([FromQuery]string dataInicial, [FromQuery]string dataFinal) => {
    return dataInicial + " - " + dataFinal;    
    });


app.MapGet("/produto/{code}", ([FromRoute]string codigo) => {
    var produto = ProdutoRepositorio.GetBy(codigo);
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
        return Produtos.First(p =>p.Codigo ==codigo);
    }
 }