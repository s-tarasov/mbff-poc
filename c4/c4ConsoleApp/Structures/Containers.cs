using C4Sharp.Elements;
using C4Sharp.Elements.Containers;

namespace C4ConsoleApp.Structures;

public static class Containers
{
    public static Container WebGateway { get; } = new Container(
        alias: "WebGateway",
        type: ContainerType.None,
        label: "Web Gateway",
        description: "Направляет запросы к сайту beeline.ru",
        technology: "C#, YARP",
        tags: new List<string>() { "platform" }
     );

    public static Container FrontPlaform { get; } = new Container(
        alias: "FrontEnv",
        type: ContainerType.None,
        label: "Frontend Platform",
        description: "среда исполения микрофронтов",
        technology: "Nodejs",
         tags: new List<string>() { "platform" }
     );

    public static Container ProductPageBFF { get; } = new Container(
        alias: "ProductPageBFF",
        type: ContainerType.Microservice,
        label: "Product Page BFF",
        description: "BFF страницы товара",
        technology: "ASP.NET",
        tags : new List<string>() { "teamred" }
     );

     public static Container ProductPageFront { get; } = new Container(
        alias: "ProductPageFront",
        type: ContainerType.Microservice,
        label: "Product Page Front",
        description: "Front страницы товара",
        technology: "Js",
        tags : new List<string>() { "teamred" }
     );

    public static Container ProductMS { get; } = new Container(
        alias: "ProductMS",
        type: ContainerType.Microservice,
        label: "Product MS",
        description: "MS товаров",
        technology: "ASP.NET",
        tags: new List<string>() { "teamred" }
     );

    public static Container InspireMSBFF { get; } = new Container(
        alias: "InspireMSBFF",
        type: ContainerType.Microservice,
        label: "InspireMSBFF",
        description: "BFF блока рекомендаций и API рекомендаций",
        technology: "ASP.NET",
        tags: new List<string>() { "teamgreen" }
     );

    public static Container BasketWidgetBFF { get; } = new Container(
        alias: "BasketBlockBFF",
        type: ContainerType.Microservice,
        label: "Basket Block BFF",
        description: "BFF страницы заказа",
        technology: "ASP.NET",
        tags: new List<string>() { "teamblue" }
    );

    public static Container BasketMS { get; } = new Container(
        alias: "BasketMS",
        type: ContainerType.Microservice,
        label: "Basket MS",
        description: "MS оформления заказа",
        technology: "ASP.NET",
        tags: new List<string>() { "teamblue" }
    );

}