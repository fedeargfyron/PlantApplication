using Domain.Dtos.PlantRisks;

namespace Application.Handlers.RiskAlerts.GetRiskAlertsHandler;

public interface IGetRiskAlertsHandler
{
    Task<List<PlantRiskDto>> HandleAsync(GetRiskAlertsHandlerRequest request);
}