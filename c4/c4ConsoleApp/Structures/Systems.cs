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
        Description = "�������������� � B2C ���������"
    };
}
