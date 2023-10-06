namespace Infrastructure.Extensions;

public static class StringExtensions
{
    public static string GetJsonFromText(this string value)
    {
        value = value.Replace("{", "|{");
        value = value.Replace("}", "}|");
        return value.Split('|')[1];
    }
}
