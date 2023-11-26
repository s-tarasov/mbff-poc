using C4Sharp.Elements;
using C4Sharp.Elements.Relationships;

namespace C4ConsoleApp.Structures;

public static class People
{
    private static Person? _customer;

    public static Person Customer => _customer ??= new Person("customer", "WebSite Customer")
    {
        Description = "A customer of shop.example website",
        Boundary = Boundary.External
    };
}
