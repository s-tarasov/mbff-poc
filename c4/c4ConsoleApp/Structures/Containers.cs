using C4Sharp.Elements;
using C4Sharp.Elements.Containers;

namespace C4ConsoleApp.Structures;

public static class Containers
{
    public static Container WebGateway { get; } = new Container(
        alias: "WebGateway",
        type: ContainerType.None,
        label: "Web Gateway",
        description: "���������� ������� � ����� beeline.ru",
        technology: "C#, YARP",
        tags: new List<string>() { "platform" }
     );

    /*
    public static Container FrontPlaform { get; } = new Container(
        alias: "FrontPlaformSystem",
        type: ContainerType.None,
        label: "Front PlaformSystem",
        description: "��������� ����������� � lowcode",
        technology: "Nodejs"
     );
    */

    public static Container ProductPageBFF { get; } = new Container(
        alias: "ProductPageBFF",
        type: ContainerType.Microservice,
        label: "Product Page BFF",
        description: "BFF �������� ������",
        technology: "ASP.NET",
        tags : new List<string>() { "teamproduct" }
     );

    public static Container ProductMS { get; } = new Container(
        alias: "ProductMS",
        type: ContainerType.Microservice,
        label: "Product MS",
        description: "MS �������",
        technology: "ASP.NET",
        tags: new List<string>() { "teamproduct" }
     );

    public static Container InspireMSBFF { get; } = new Container(
        alias: "InspireMSBFF",
        type: ContainerType.Microservice,
        label: "InspireMSBFF",
        description: "BFF ����� ������������ � API ������������",
        technology: "ASP.NET",
        tags: new List<string>() { "teaminspire" }
     );

    public static Container BasketWidgetBFF { get; } = new Container(
        alias: "BasketBlockBFF",
        type: ContainerType.Microservice,
        label: "Basket Block BFF",
        description: "BFF �������� ������",
        technology: "ASP.NET",
        tags: new List<string>() { "teambasket" }
    );

    public static Container BasketMS { get; } = new Container(
        alias: "BasketMS",
        type: ContainerType.Microservice,
        label: "Basket MS",
        description: "MS ���������� ������",
        technology: "ASP.NET",
        tags: new List<string>() { "teambasket" }
    );

}