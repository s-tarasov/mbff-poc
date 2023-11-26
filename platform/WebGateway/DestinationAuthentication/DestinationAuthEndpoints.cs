namespace WebGateway.DestinationAuthentication;

public static class DestinationAuthEndpoints
{
    public static void UseDestinationAuthenticationEndpoints(this WebApplication app)
    {
        app.UseJwksDiscovery();
    }
}