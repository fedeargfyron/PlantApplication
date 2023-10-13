using Domain.Dtos.PlantRisks;
using Domain.Entities;

namespace Domain.Extensions;

public static class PlantRiskDtoListExtensions
{
    public static List<PlantRisk> ConvertToEntities(this List<PlantRiskDto> dtos)
        => dtos.SelectMany(x => x.Risks.Select(r => new PlantRisk
        {
            Day = r.Day,
            Description = r.Description,
            Level = r.Level,
            PlantId = x.PlantId,
            Risk = r.Risk
        })).ToList();
}
