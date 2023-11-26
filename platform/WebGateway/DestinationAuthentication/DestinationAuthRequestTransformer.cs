using System.Security.Claims;

using NetDevPack.Security.Jwt.Core.Interfaces;

using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;
using System.IdentityModel.Tokens.Jwt;

namespace WebGateway.DestinationAuthentication;

public static class DestinationAuthRequestTransformer
{
    public static void Transform(TransformBuilderContext builderContext)
    {
        var handler = new JwtSecurityTokenHandler();

        builderContext.AddRequestTransform(async transformContext =>
            {
                transformContext.ProxyRequest.Headers.Remove("X-GW-Jwt-Assertion");

                var jwtService = transformContext.HttpContext.RequestServices.GetService<IJwtService>();

                var token = new JwtSecurityToken(
                    claims: new[]
                    {
                        new Claim(ClaimTypes.Name, "webg"),
                        new Claim("dest", builderContext.Cluster.ClusterId)
                    },
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: await jwtService.GetCurrentSigningCredentials());
                var jwt = handler.WriteToken(token);

                transformContext.ProxyRequest.Headers.Add("X-GW-Jwt-Assertion", jwt);
            });
    }
}
