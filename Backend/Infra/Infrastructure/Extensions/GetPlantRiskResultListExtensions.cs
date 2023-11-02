using Domain.Dtos.PlantRisks;
using Infrastructure.ExternalServices.GPT.Contracts;

namespace Infrastructure.Extensions;

public static class GetPlantRiskResultListExtensions
{
    public static List<GetPlantRiskResultDto> ConvertToDtos(this List<GetPlantRiskResult> plantsRiskResults)
        => plantsRiskResults.Select(x =>
        {
            return new GetPlantRiskResultDto()
            {
                PlantScientificName = x.Plant,
                Risks = x.Risks.Select(x => new RiskDto()
                {
                    Day = DateTime.Today.AddDays(x.Day),
                    Description = x.Description,
                    Level = x.Level,
                    Risk = x.Risk
                }).ToList(),
            };
        }).ToList();
}

