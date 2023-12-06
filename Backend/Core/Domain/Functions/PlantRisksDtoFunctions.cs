using Domain.Dtos.PlantRisks;
using Domain.Dtos.WateringCalendar;
using Domain.Dtos.Weather.GetWeatherDtoContent;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Functions;

public static class PlantRisksDtoFunctions
{
    //TODO: Agregar forecastDays y wateringDays filters
    public static List<PlantRiskDto> FilterPlantRisks(List<PlantRiskDto> plantRisks, List<ForecastDayDto> forecastDays, List<GetPlantWithWateringDaysFromUserResultDto> wateringDays)
    {
        plantRisks.ForEach(x =>
        {
            x.Risks = x.Risks.Where(r => x.Outside || (r.Risk != Risks.Rain.ToString() && r.Risk != Risks.Wind.ToString()))
                .ToList();
        });
        return plantRisks.Where(x => x.Risks.Any()).ToList();
    }
}
