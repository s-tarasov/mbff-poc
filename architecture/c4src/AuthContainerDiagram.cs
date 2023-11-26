using C4ConsoleApp.Structures;
using C4Sharp.Diagrams;
using C4Sharp.Diagrams.Interfaces;
using C4Sharp.Elements;
using C4Sharp.Elements.Boundaries;
using C4Sharp.Elements.Plantuml;
using C4Sharp.Elements.Plantuml.Constants;
using C4Sharp.Elements.Relationships;

using static C4ConsoleApp.Structures.Containers;

namespace C4ConsoleApp;

public class AuthContainerDiagram : DiagramBuildRunner
{
    protected override string Title => "Container diagram of authentication in micro BFF protoptype";
    protected override DiagramType DiagramType => DiagramType.Container;

    protected override IEnumerable<Structure> Structures => new Structure[]
    {
        People.Customer,
        IdentityServer,
        new SoftwareSystemBoundary("c1", Systems.B2C.Label, 
            WebGateway,
            FrontPlaform,
            ProductPageFront,
            ProductPageBFF),

        new SoftwareSystemBoundary("c2", Systems.Core.Label, 
            ApiGateway,
            ProductMS),
    };

    protected override IEnumerable<Relationship> Relationships => new[]
    {
        People.Customer > WebGateway | ("Uses", "HTTPS, encrypted auth cookies"),
        People.Customer > IdentityServer | ("Login to shop", "HTTPS, Authorization Code Flow"),
        WebGateway > IdentityServer | ("Request fresh tokens using refresh token", "HTTPS"),
        WebGateway > IdentityServer | ("Request JWKS", "HTTPS"),
        WebGateway > FrontPlaform | "Proxy page requests",
        WebGateway < FrontPlaform | "Proxy API requests",
        FrontPlaform > ProductPageFront | "Execute",
        WebGateway > ProductPageBFF | """
        Proxy Product Page BFF requests.
        Replace auth cooky with x-user header.
        Add x-gw-id header
        """.ToPlant(),
        WebGateway < ProductPageBFF | "Request JWKS for x-gw-id header",
        ProductPageBFF > ApiGateway | ("Request Product Info", "HTTPS, acces_token"),
        ProductPageBFF > ApiGateway | ("Request access_token. OAUTH", "HTTPS"),
        ApiGateway > ProductMS | ("Proxy API requests", "JWKS_ASSERTION")
    };

    protected override IElementTag SetTags()
    {
        return new ElementTag()
            .AddElementTag("teamred", "#B22222")
            .AddElementTag("teamgreen", "#008000")
            .AddElementTag("teamblue", "#0000FF")
            .AddElementTag("platform", "#2F4F4F", shape: Shape.EightSidedShape);
    }
}