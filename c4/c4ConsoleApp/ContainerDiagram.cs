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
            ProductPageBFF,
            ProductMS,
            InspireMSBFF,
            BasketWidgetBFF,
            BasketMS),
    };

    protected override IEnumerable<Relationship> Relationships => new[]
    {
        People.Customer > WebGateway | ("Uses", "HTTPS"),
        WebGateway > ProductPageBFF | "Proxy Product Page BFF requests",
        WebGateway > InspireMSBFF | "Proxy Recomendation Block BFF requests",
        WebGateway > BasketWidgetBFF | "Proxy Checkout Page BFF requests",
        ProductPageBFF > ProductMS | "Request Product Info",
        InspireMSBFF > ProductMS | "Request Product Info" | Position.Neighbor,
        BasketWidgetBFF > BasketMS | "Request Basket State"
    };

    protected override IElementTag SetTags()
    {
        return new ElementTag()
            .AddElementTag("teamproduct", "#B22222")
            .AddElementTag("teaminspire", "#008000")
            .AddElementTag("teambasket", "#2F4F4F")
            .AddElementTag("platform", "#0000FF", shape: Shape.EightSidedShape);
    }
}