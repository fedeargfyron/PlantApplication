using Domain.Dtos.WateringCalendar;
using Domain.Entities;

namespace Domain.Extensions;

public static class GetWateringDayFromUserResultDtoListExtensions
{
    public static List<WateringDay> GetNewMaximumWateringDayEntities(this List<GetWateringDayFromUserResultDto> wateringDays, DateTime newMaximumCalculatedWateringDay)
    {
        var maximumPlantWateringDay = wateringDays.Select(x => new { x.Id, x.WateringDaysFrequency, MaxDate = x.WateringSpecificDates.Max() }).ToList();
        return maximumPlantWateringDay.SelectMany(x => 
        {
            var entities = x.WateringDaysFrequency.GetWateringDays(x.MaxDate, newMaximumCalculatedWateringDay);
            entities.ForEach(e => e.PlantId = x.Id);
            return entities;
        }).ToList();
    }

    public static List<string> GetScientificNames(this List<GetWateringDayFromUserResultDto> wateringDays)
        => wateringDays.Select(x => x.ScientificName)
            .Distinct()
            .ToList();
}
