using Domain.Dtos.PlantRisks;
using Domain.Dtos.WateringCalendar;
using Domain.Entities;

namespace Domain.Extensions;

public static class GetPlantRiskResultDtoListExtensions
{
    public static List<PlantRiskDto> ConvertToDtos(this List<GetPlantRiskResultDto> dtos, List<GetPlantWithWateringDaysFromUserResultDto> plantsWithWateringDays)
        => dtos.SelectMany(x => {
            var plants = plantsWithWateringDays.Where(w => w.ScientificName == x.PlantScientificName).ToList();
            return plants.Select(p => new PlantRiskDto()
            {
                PlantId = p.Id,
                PlantScientificName = x.PlantScientificName,
                Outside = p.Outside,
                Risks = x.Risks
            });
        }).ToList();

    public static List<PlantRisk> ConvertToEntities(this List<GetPlantRiskResultDto> dtos, List<GetPlantWithWateringDaysFromUserResultDto> plantsWithWateringDays)
        => dtos.SelectMany(x => {
            var plants = plantsWithWateringDays.Where(w => w.ScientificName == x.PlantScientificName).ToList();
            return plants.SelectMany(p =>
                x.Risks.Select(r => new PlantRisk
                {
                    Day = r.Day,
                    Description = r.Description,
                    Level = r.Level,
                    PlantId = p.Id,
                    Risk = r.Risk,
                }).ToList()
            );
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
