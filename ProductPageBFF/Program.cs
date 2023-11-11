var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var producMsClient = new ProductPageBFF.ProductMsClient("http://localhost:5087/", new HttpClient());

app.MapGet("/productpage/{productId}", async (int productId) =>
{
    var product = await producMsClient.GetProductAsync(productId);
    return product;
})
.WithName("GetProductPage")
.WithOpenApi(o => 
{
  o.Parameters[0].Example = new Microsoft.OpenApi.Any.OpenApiInteger(1);
 return o;
});

app.Run();
