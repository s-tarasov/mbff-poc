namespace WebGateway.DestinationAuthentication;

public static class DestinationAuthSetup
{
    public static void AddDestinationAuthServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache();
        builder.Services.AddJwksManager();
    }
}
