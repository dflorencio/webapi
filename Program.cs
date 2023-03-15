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
    return produto.Codigo + " - " + produto.Nome;
});

app.MapPost("/livro", (Livro livro) => {
    return livro.descricao ;
});

// Via parametro 
app.MapGet("/produto" , ([FromQuery]string dataInicial, [FromQuery]string dataFinal) => {
    return dataInicial + " - " + dataFinal;    
    });


app.MapGet("/produto/{code}", ([FromRoute]string code) => {
    return code;
});
   
app.MapGet("/getproduto",(HttpRequest request) => {
    return request.Headers["produto-codigo"].ToString();
});


app.Run();




public class Produto {
    public string Codigo { get; set; }
    public string  Nome { get; set; }
}


public class Livro
 {
    public string imgCapa { get; set; }
    public string descricao { get; set; }
    public string  titulo { get; set; }
   
 }