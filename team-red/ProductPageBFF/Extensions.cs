public static class Extensions
{
    public static string? NullIfEmpty(this string? value) => value?.Length > 0 ? value : null; 
}