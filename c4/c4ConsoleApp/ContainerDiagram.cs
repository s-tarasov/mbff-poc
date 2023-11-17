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

public class ContainerDiagram : DiagramBuildRunner
{
    protected override string Title => "Container diagram of micro BFF protoptype";
    protected override DiagramType DiagramType => DiagramType.Container;

    protected override IEnumerable<Structure> Structures => new Structure[]
    {
        People.Customer,
        new SoftwareSystemBoundary("c1", Systems.B2C.Label, 
            WebGateway,
            FrontPlaform,
            ProductPageFront,
            ProductPageBFF,
            ProductMS,
            InspireFront,
            InspireBFF,
            InspireMS,
            BasketMS),
    };

    protected override IEnumerable<Relationship> Relationships => new[]
    {
        People.Customer > WebGateway | ("Uses", "HTTPS"),
        WebGateway > FrontPlaform | "Proxy page requests",
        WebGateway < FrontPlaform | "Proxy API requests",
        FrontPlaform > ProductPageFront | "Execute",
        FrontPlaform > InspireFront | "Execute",
        WebGateway > ProductPageBFF | "Proxy Product Page BFF requests",
        WebGateway > InspireBFF | "Proxy Recomendation Block BFF requests",
        ProductPageBFF > BasketMS | "Request Basket State",
        ProductPageBFF > ProductMS | "Request Product Info",
        InspireBFF > InspireMS | "Request Recomendations",
        InspireBFF > ProductMS | "Request Product Info"
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