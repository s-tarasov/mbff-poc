using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);


var pageRoutes = new[] { ("product/{**catch-all}", "product") };

var yarpRoutes = pageRoutes.Select(r => MapRoute(r.Item1, r.Item2)).ToList();

builder.Services.AddReverseProxy()
    .LoadFromMemory(yarpRoutes, Array.Empty<ClusterConfig>())
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

RouteConfig MapRoute(string pattern, string page)
{
    var route = new RouteConfig
    {
        RouteId = pattern,
        Match = new RouteMatch
        {
            Path = pattern
        },
        ClusterId = "frontendPlatform"
    }
    .WithTransformRequestHeader(headerName: "X-Page", value: page, append: false);
return route;


}

app.UseHttpsRedirection();
app.MapReverseProxy();
app.Run();
