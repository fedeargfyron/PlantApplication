using Domain.Entities;
using Domain.Functions;

namespace Domain.Extensions;

public static class StringExtensions
{
    private const string wateringDayRangeDelimiter = "-";
    public static List<WateringDay> GetWateringDays(this string value, DateTime initialDate, DateTime maximumCalculatedDate)
        => value.Contains(wateringDayRangeDelimiter)
            ? WateringDaysFunctions.ConvertWithRangeDays(value, initialDate, maximumCalculatedDate)
            : WateringDaysFunctions.ConvertWithSingleDay(value, initialDate, maximumCalculatedDate);
}
