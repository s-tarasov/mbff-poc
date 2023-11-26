using C4Sharp.Elements;

namespace C4ConsoleApp.Structures;

public static class Systems
{
    /// /////////////////////////////////// <summary>
    /// ///////////////////////////////////
    /// </summary>
    public static SoftwareSystem B2C { get; } = new SoftwareSystem(
        "ShopExample",
        "Shop Example")
    {
        Description = "Shop B2C"
    };

    public static SoftwareSystem Core { get; } = new SoftwareSystem(
        "ShopExample Core",
        "Shop Example Core")
    {
        Description = "Shop Core"
    };
}
