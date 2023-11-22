namespace C4ConsoleApp;

public static class PlantTextExtensions
{
    public static string ToPlant(this string text) => string.Join("\\n", text.Split(Environment.NewLine));
}