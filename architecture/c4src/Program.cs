using C4ConsoleApp;

using C4Sharp.Elements.Plantuml.IO;

var diagrams = new[]
{
    new ContainerDiagram().Build(),
    new AuthContainerDiagram().Build()
};

var context = new PlantumlContext();

context
    .UseDiagramImageBuilder()
    .UseDiagramSvgImageBuilder()
    .Export(Directory.GetCurrentDirectory() + "\\..", diagrams);