using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace WebGateway.UserAuthentication;

public static class UserAuthSetup
{
    public static void AddUserAuthServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
        .AddCookie(setup =>
        {
            setup.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            setup.SlidingExpiration = true;
        })
        .AddOpenIdConnect(options =>
        {
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.Authority = "http://localhost:51990";
            options.ClientId = "webgateway";
            options.UsePkce = false;
            options.MapInboundClaims = false;
            options.ClientSecret = "webgateway-secret";
            options.ResponseType = OpenIdConnectResponseType.Code;
            options.SaveTokens = true;
            options.RequireHttpsMetadata = false;
            options.Scope.Clear();
            options.Scope.Add("openid");
        });
    }
}