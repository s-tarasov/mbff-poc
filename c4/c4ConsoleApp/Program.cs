using C4Sharp.Elements.Plantuml.IO;

namespace C4ConsoleApp;

internal static class Program
{
    private static void Main()
    {
        var diagrams = new[]
        {
            new ContainerDiagram().Build(),
            new AuthContainerDiagram().Build()
        };

        var context = new PlantumlContext();

        context
            .UseDiagramImageBuilder()
            .UseDiagramSvgImageBuilder()
            .Export(diagrams);
    }
}