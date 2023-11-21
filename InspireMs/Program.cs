var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
var productToRecomendations = new Dictionary<int, Recomendation[]>
{
 [1] = new [] { 
  new Recomendation(2, "trailer_red"),
  new Recomendation(2, "trailer_green"),
  new Recomendation(2, "trailer_blue")
  },
  [2] = new [] { 
  new Recomendation(1, "t_porsche"),
  new Recomendation(1, "t_fendt"),
  new Recomendation(1, "t_eicher")
  }
};

app.MapGet("/recomendations/", async (int forProductId) =>
{
    await Task.Delay(500);
    return productToRecomendations[forProductId].OrderBy(f => Guid.NewGuid());
})
.WithName("GetRecomendations")
.WithOpenApi(o => 
{
  o.Parameters[0].Example = new Microsoft.OpenApi.Any.OpenApiInteger(1);
 return o;
});

app.Run();

record Recomendation(int productId, string sku);