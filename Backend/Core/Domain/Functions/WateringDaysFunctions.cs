using Domain.Entities;

namespace Domain.Functions;

public static class WateringDaysFunctions
{
    private const string wateringDayRangeDelimiter = "-";
    public static List<WateringDay> ConvertWithRangeDays(string wateringDaysFrequency, DateTime initialDate, DateTime maximumCalculatedDate)
    {
        var splittedValues = wateringDaysFrequency.Split(wateringDayRangeDelimiter);
        var minimum = Convert.ToInt32(splittedValues[0]);
        var maximum = Convert.ToInt32(splittedValues[1]);
        var currentDate = initialDate;
        var random = new Random();
        var wateringDays = new List<WateringDay>();
        while (currentDate < maximumCalculatedDate)
        {
            wateringDays.Add(new() { Day = currentDate });
            currentDate = currentDate.AddDays(random.Next(minimum, maximum + 1));
        };
        return wateringDays;
    }
    public static List<WateringDay> ConvertWithSingleDay(string wateringDaysFrequency, DateTime initialDate, DateTime maximumCalculatedDate)
    {
        var currentDate = initialDate;
        var wateringFrequency = Convert.ToInt32(wateringDaysFrequency);
        var wateringDays = new List<WateringDay>();
        while (currentDate < maximumCalculatedDate)
        {
            wateringDays.Add(new() { Day = currentDate });
            currentDate = currentDate.AddDays(wateringFrequency);
        };
        return wateringDays;
    }
}
