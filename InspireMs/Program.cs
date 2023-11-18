var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var productToRecomendations = new Dictionary<int, Recomendation[]>
{
 [1] = new [] { new Recomendation(1, "t_porsche")}
};

app.MapGet("/recomendations/", (int forProductId) =>
{
    return productToRecomendations[forProductId];
})
.WithName("GetRecomendations")
.WithOpenApi(o => 
{
  o.Parameters[0].Example = new Microsoft.OpenApi.Any.OpenApiInteger(1);
 return o;
});

app.Run();

record Recomendation(int productId, string sku);