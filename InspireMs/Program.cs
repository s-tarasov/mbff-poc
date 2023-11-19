var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
/*

        new ProductVariant (
            sku: "t_porsche",
            name: "Porsche-Diesel Master 319",
            image: "/static/ProductMs/images/tractor-red.jpg",
            price: 66m
        ),
        new ProductVariant (
            sku: "t_fendt",
            name: "Fendt F20 Dieselroß",
            image: "/static/ProductMs/images/tractor-green.jpg",
            price: 54m
        ),
        new ProductVariant (
            sku: "t_eicher",
            name: "Eicher Diesel 215/16",
            image: "/static/ProductMs/images/tractor-blue.jpg",
            price: 58m
        )
    }),
     new Product(2, "trailer", new[]
    {
        new ProductVariant (
            sku: "trailer_red",
            name: "trailer_red",
            image: "/static/ProductMs/images/trailer-red.jpg",
            price: 1m
        ),
        new ProductVariant (
            sku: "trailer_green",
            name: "trailer_green",
            image: "/static/ProductMs/images/trailer-green.jpg",
            price: 2m
        ),
        new ProductVariant (
            sku: "trailer_blue",
            name: "trailer_blue",
            image: "/static/ProductMs/images/trailer-blue.jpg",
            price: 3m
        )
    })
*/
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

app.MapGet("/recomendations/", (int forProductId) =>
{
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