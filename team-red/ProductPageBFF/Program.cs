var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var producMsClient = new ProductPageBFF.ProductMsClient("http://localhost:5087/", new HttpClient());

var basketMsClient = new ProductPageBFF.BasketMsClient("http://localhost:5058/", new HttpClient());

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

app.MapGet("/basketcount/", async (HttpContext context) =>
{    
    var basketId = context.Request.Headers["X-USER"][0].NullIfEmpty() ?? context.Request.Cookies["basketId"];
    if (basketId is null)
      return new { Count = 0 };

    var basketResponse = await basketMsClient.GetBasketAsync(basketId);

    return new { basketResponse.Count };
})
.WithName("GetBasketCount");

app.MapPost("/add-basket-item/", async (HttpContext context) =>
{
    var basketId = context.Request.Headers["X-USER"][0].NullIfEmpty() ?? context.Request.Cookies["basketId"];
    if (basketId is null)
    {
        basketId = Guid.NewGuid().ToString();
        context.Response.Cookies.Append("basketId", basketId);
    }
    var basketResponse = await basketMsClient.AddItemToBasketAsync(basketId);

     return new { basketResponse.Count };
})
.WithName("AddItemToBasket");

app.Run();
