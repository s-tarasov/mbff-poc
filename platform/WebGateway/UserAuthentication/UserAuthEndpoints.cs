using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace WebGateway.UserAuthentication;

public static class UserAuthEndpoints
{
    public static void UseUserAuthenticationEndpoints(this WebApplication app)
    {
        app.MapGet("/login", (string? redirectUrl, HttpContext ctx) =>
        {

            if (string.IsNullOrEmpty(redirectUrl))
            {
                redirectUrl = "/";
            }

            ctx.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = redirectUrl
            });
        });

        app.MapGet("/user", (HttpContext ctx) =>
        {
            return new
            {
                Claims = ctx.User.Claims.Select(c => new { c.Type, c.Value })
            };
        });
    }

}