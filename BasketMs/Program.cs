var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
var basketToItemsCount = new Dictionary<string, int>
{
};

app.MapGet("/basket/{id}/", async (string id) =>
{
    await Task.Delay(300);
    var count = basketToItemsCount.GetValueOrDefault(id);
    return new { count };
})
.WithName("GetBasket")
.WithOpenApi(o =>
{
    o.Parameters[0].Example = new Microsoft.OpenApi.Any.OpenApiString("abc");
    return o;
});

app.MapPost("/basket/{id}/add-item", async (string id) =>
{
    await Task.Delay(300);

    var count = basketToItemsCount.GetValueOrDefault(id);
    count++;
    basketToItemsCount[id] = count;

    return new { count };
})
.WithName("AddItemToBasket")
.WithOpenApi(o =>
{
    o.Parameters[0].Example = new Microsoft.OpenApi.Any.OpenApiString("abc");
    return o;
});

app.Run();