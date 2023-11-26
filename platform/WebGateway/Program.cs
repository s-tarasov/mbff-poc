using WebGateway.Authentication;

using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);


var pageRoutes = new[] 
{ 
    ("product", "product"),
    ("best/product", "product"),
    ("notimpl", "notimpl") 
};

var yarpRoutes = pageRoutes.Select(r => MapRoute(r.Item1, r.Item2)).ToList();

builder.Services.AddReverseProxy()
    .LoadFromMemory(yarpRoutes, Array.Empty<ClusterConfig>())
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddTransforms(AuthRequestTransformer.Transform);

builder.AddAuthServices();

var app = builder.Build();

RouteConfig MapRoute(string pattern, string page)
{
    return new RouteConfig
    {
        RouteId = pattern,
        Match = new RouteMatch
        {
            Path = pattern + "/{**catch-all}"
        },
        ClusterId = "frontendPlatform"
    }
    .WithTransformRequestHeader(headerName: "X-Page", value: page, append: false)
    .WithTransformRequestHeader(headerName: "X-Page-Base-Url", value: "/" + pattern, append: false);
}
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "..", "..")),
    RequestPath = "/static"
});

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthenticationEndpoints();
app.MapReverseProxy();
app.Run();
