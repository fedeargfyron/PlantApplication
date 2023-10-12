using Domain.Dtos.PlantRisks;
using Domain.Dtos.Weather.GetWeatherDtoContent;
using Domain.Enums;

namespace Domain.Functions;

public static class PlantRisksFunctions
{
    public static List<PlantRiskDto> FilterPlantRisks(List<PlantRiskDto> plantRisks, List<ForecastDayDto> forecastDays)
    {
        plantRisks.ForEach(x =>
        {
            x.Risks = x.Risks.Where(r => x.Outside || (r.Risk != Risks.Rain.ToString() && r.Risk != Risks.Wind.ToString()))
                .ToList();
        });

        //Filtrar vientos bajos
        //Filtrar bajas probabilidades de lluvia
        //Filtrar riesgos bajos
        return plantRisks.Where(x => x.Risks.Any()).ToList();
    }
}
