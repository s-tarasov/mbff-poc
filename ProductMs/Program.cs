var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var products = new[]
{
    new Product(1, "tractor", new[]
    {
        new ProductVariant (
            sku: "t_porsche",
            name: "Porsche-Diesel Master 419",
            image: "/red/images/tractor-red.jpg",
            price: 66m
        ),
        new ProductVariant (
            sku: "t_fendt",
            name: "Fendt F20 Dieselroß",
            image: "/red/images/tractor-green.jpg",
            price: 54m
        ),
        new ProductVariant (
            sku: "t_eicher",
            name: "Eicher Diesel 215/16",
            image: "/red/images/tractor-blue.jpg",
            price: 58m
        )
    })
};

app.MapGet("/products/{id}", (int id) =>
{
    return products.FirstOrDefault(p => p.id == id);
})
.WithName("GetProduct")
.WithOpenApi(o => 
{
  o.Parameters[0].Example = new Microsoft.OpenApi.Any.OpenApiInteger(1);
 return o;
});

app.Run();

record Product(int id, string name, ProductVariant[] variants);

record ProductVariant(string sku, string name, string image, decimal price);
