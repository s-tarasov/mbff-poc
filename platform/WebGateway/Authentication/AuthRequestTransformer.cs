using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;

namespace WebGateway.Authentication;

public static class AuthRequestTransformer
{
    public static void Transform(TransformBuilderContext builderContext) 
    {
        builderContext.AddRequestTransform(async transformContext =>
            {
                transformContext.ProxyRequest.Headers.Remove("X-USER");

                transformContext.ProxyRequest.Headers.Add("X-USER", 
                    transformContext.HttpContext.User.FindFirst("email")?.Value);
            });
    }
}
