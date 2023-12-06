using Domain.Entities;
using Domain.Functions;
using System.Text;

namespace Domain.Extensions;

public static class StringExtensions
{
    private const string wateringDayRangeDelimiter = "-";
    public static List<WateringDay> GetWateringDays(this string value, DateTime initialDate, DateTime maximumCalculatedDate)
        => value.Contains(wateringDayRangeDelimiter)
            ? WateringDaysFunctions.ConvertWithRangeDays(value, initialDate, maximumCalculatedDate)
            : WateringDaysFunctions.ConvertWithSingleDay(value, initialDate, maximumCalculatedDate);

    public static string Capitalize(this string value)
        => value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();

    public static string RemoveSpecialCharacters(this string str)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in str)
        {
            if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}
