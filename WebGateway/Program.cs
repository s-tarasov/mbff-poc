using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);


var pageRoutes = new[] { ("product/{**catch-all}", "product") };

var yarpRoutes = pageRoutes.Select(p => new RouteConfig
{
    RouteId = p.Item2,
    Metadata = new Dictionary<string, string> { ["page"] = p.Item2 },
    Match = new RouteMatch
    {
        Path = p.Item1
    },
    ClusterId = "frontendPlatform"
})
.ToList();

builder.Services.AddReverseProxy()
    .LoadFromMemory(yarpRoutes, Array.Empty<ClusterConfig>())
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();



app.UseHttpsRedirection();
app.MapReverseProxy();
app.Run();
