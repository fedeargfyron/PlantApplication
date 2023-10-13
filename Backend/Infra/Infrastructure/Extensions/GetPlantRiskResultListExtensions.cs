using Domain.Dtos.PlantRisks;
using Domain.Dtos.WateringCalendar;
using Infrastructure.ExternalServices.GPT.Contracts;

namespace Infrastructure.Extensions;

public static class GetPlantRiskResultListExtensions
{
    public static List<PlantRiskDto> ConvertToDtos(this List<GetPlantRiskResult> plantsRiskResults, List<GetWateringDayFromUserResultDto> wateringDays)
        => plantsRiskResults.Select(x =>
        {
            var wateringDay = wateringDays.First(w => w.ScientificName == x.Plant);
            return new PlantRiskDto()
            {
                PlantId = wateringDay.Id,
                PlantScientificName = wateringDay.ScientificName,
                Risks = x.Risks.Select(x => new RiskDto()
                {
                    Day = DateTime.Today.AddDays(x.Day),
                    Description = x.Description,
                    Level = x.Level,
                    Risk = x.Risk
                }).ToList(),
                Outside = wateringDay.Outside
            };
        }).ToList();
}

