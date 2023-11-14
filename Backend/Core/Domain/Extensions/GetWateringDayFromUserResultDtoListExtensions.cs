using Domain.Dtos.WateringCalendar;
using Domain.Entities;

namespace Domain.Extensions;

public static class GetWateringDayFromUserResultDtoListExtensions
{
    public static List<WateringDay> GetNewMaximumWateringDayEntities(this List<GetPlantWithWateringDaysFromUserResultDto> plantWithWateringDays, DateTime newMaximumCalculatedWateringDay)
    {
        var maximumPlantWateringDay = plantWithWateringDays.Select(x => new { x.Id, x.WateringDaysFrequency, MaxDate = x.WateringSpecificDates.Any() ? x.WateringSpecificDates.Max() : DateTime.Today }).ToList();
        return maximumPlantWateringDay.SelectMany(x => 
        {
            var entities = x.WateringDaysFrequency.GetWateringDays(x.MaxDate, newMaximumCalculatedWateringDay);
            entities.ForEach(e => e.PlantId = x.Id);
            return entities;
        }).ToList();
    }

    public static List<string> GetScientificNames(this List<GetPlantWithWateringDaysFromUserResultDto> plantWithWateringDays)
        => plantWithWateringDays.Select(x => x.ScientificName)
            .Distinct()
            .ToList();
}
