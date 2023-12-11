using Domain.Entities;
using Domain.Extensions;

namespace Domain.Functions;

public static class PlantRisksFunctions
{
    private static readonly List<string> _allowedKeywords = new List<string> { "rain", "temperature", "humidity", "wind"};
    public static List<PlantRisk> CleanPlantRisks(List<PlantRisk> plantRisks)

        => plantRisks.Where(x => _allowedKeywords.Any(a => x.Risk.ToLowerInvariant().Contains(a)))
                .Select(x =>
                {
                    var splittedRisk = x.Risk.ToLowerInvariant().Split(' ');
                    var allowedRisk = splittedRisk.Single(p => _allowedKeywords.Any(a => p.ToLowerInvariant().Contains(a)));
                    x.Risk = allowedRisk.RemoveSpecialCharacters()
                                        .Capitalize();

                    return x;
                })
                .GroupBy(x => new { x.Day, x.PlantId, x.Risk })
                .Select(x => new PlantRisk()
                {
                    Day = x.Key.Day,
                    PlantId = x.Key.PlantId,
                    Risk = x.Key.Risk,
                    Description = x.First().Description,
                    Id = x.First().Id,
                    Level = x.First().Level,
                    ObtentionDate = x.First().ObtentionDate
                })
                .ToList();
}