using Domain.Dtos.PlantRisks;
using Domain.Dtos.WateringCalendar;
using Domain.Entities;

namespace Domain.Extensions;

public static class GetPlantRiskResultDtoListExtensions
{
    private static readonly List<string> _allowedKeywords = new List<string> { "rain", "temperature", "humidity", "wind" };
    public static List<PlantRiskDto> ConvertToDtos(this List<GetPlantRiskResultDto> dtos, List<GetPlantWithWateringDaysFromUserResultDto> plantsWithWateringDays)
        => dtos.Select(x => {
            var plant = plantsWithWateringDays.First(w => w.ScientificName == x.PlantScientificName);
            return new PlantRiskDto()
            {
                PlantId = plant.Id,
                PlantScientificName = x.PlantScientificName,
                Outside = plant.Outside,
                Risks = x.Risks
            };
        }).ToList();

    public static List<PlantRisk> ConvertToEntities(this List<GetPlantRiskResultDto> dtos, List<GetPlantWithWateringDaysFromUserResultDto> plantsWithWateringDays)
        => dtos.SelectMany(x => {
            var plant = plantsWithWateringDays.First(w => w.ScientificName == x.PlantScientificName);
            return x.Risks.Select(r => new PlantRisk
            {
                Day = r.Day,
                Description = r.Description,
                Level = r.Level,
                PlantId = plant.Id,
                Risk = r.Risk,
            });
        })
        .ToList();

    public static List<PlantRisk> ConvertToEntitiesWithoutId(this List<GetPlantRiskResultDto> dtos)
    => dtos.SelectMany(x => {
        return x.Risks.Select(r => new PlantRisk
        {
            Day = r.Day,
            Description = r.Description,
            Level = r.Level,
            Risk = r.Risk
        });
    }).ToList();
}
