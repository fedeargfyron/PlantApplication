using Domain.Dtos.PlantRisks;
using Domain.Dtos.WateringCalendar;

namespace Domain.Extensions;

public static class GetPlantRiskResultDtoListExtensions
{
    public static List<PlantRiskDto> ConvertToDtos(this List<GetPlantRiskResultDto> plantsRiskResults, List<GetWateringDayFromUserResultDto> wateringDays)
        => plantsRiskResults.Select(x =>
        {
            var wateringDay = wateringDays.First(w => w.ScientificName == x.Plant);
            return new PlantRiskDto()
            {
                Day = x.Day,
                PlantId = wateringDay.Id,
                PlantScientificName = wateringDay.ScientificName,
                Risks = x.Risks,
                Outside = wateringDay.Outside
            };
        }).ToList();
}

