using C4Sharp.Elements;
using C4Sharp.Elements.Containers;

namespace C4ConsoleApp.Structures;

public static class Containers
{
    public static Container WebGateway { get; } = new Container(
        alias: "WebGateway",
        type: ContainerType.None,
        label: "Web Gateway",
        description: "Направляет запросы к сайту",
        technology: "C#, YARP",
        tags: new List<string>() { "platform" }
     );

     public static Container ApiGateway { get; } = new Container(
        alias: "ApiGateway",
        type: ContainerType.None,
        label: "ApiGateway",
        description: "Направляет запросы к MS",
        technology: "C#, YARP",
        tags: new List<string>() { "platform" }
     );

    public static Container IdentityServer { get; } = new Container(
        alias: "IdentityServer",
        type: ContainerType.None,
        label: "IdentityServer",
        description: "Идентифицирует пользователя",
        technology: "C#, Duendo IS",
        tags: new List<string>() { "platform" }
     );

    public static Container FrontPlaform { get; } = new Container(
        alias: "FrontEnv",
        type: ContainerType.None,
        label: "Frontend Platform",
        description: "Среда исполения микрофронтов",
        technology: "Nodejs",
         tags: new List<string>() { "platform" }
     );

     public static Container ProductPageFront { get; } = new Container(
        alias: "ProductPageFront",
        type: ContainerType.Microservice,
        label: "Product Page Front",
        description: "Front страницы товара",
        technology: "Js",
        tags : new List<string>() { "teamred" }
     );

    public static Container ProductPageBFF { get; } = new Container(
        alias: "ProductPageBFF",
        type: ContainerType.Microservice,
        label: "Product Page BFF",
        description: "BFF страницы товара",
        technology: "ASP.NET",
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

    public static Container InspireFront { get; } = new Container(
        alias: "InspireFront",
        type: ContainerType.Microservice,
        label: "Recommendation Block Front",
        description: "Front блока рекомендаций",
        technology: "Js",
        tags : new List<string>() { "teamgreen" }
     );

    public static Container InspireBFF { get; } = new Container(
        alias: "InspireBFF",
        type: ContainerType.Microservice,
        label: "InspireBFF",
        description: "BFF рекомендаций",
        technology: "Node.Js",
        tags: new List<string>() { "teamgreen" }
     );

    public static Container InspireMS { get; } = new Container(
        alias: "InspireMS",
        type: ContainerType.Microservice,
        label: "InspireMS",
        description: "MS рекомендаций",
        technology: "ASP.NET",
        tags: new List<string>() { "teamgreen" }
     );

    public static Container BasketMS { get; } = new Container(
        alias: "BasketMS",
        type: ContainerType.Microservice,
        label: "BasketMS",
        description: "API корзины",
        technology: "ASP.NET",
        tags: new List<string>() { "teamblue" }
    );
}