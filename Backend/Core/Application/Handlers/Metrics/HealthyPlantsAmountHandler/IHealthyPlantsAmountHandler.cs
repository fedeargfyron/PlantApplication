using Domain.Dtos.Metrics;

namespace Application.Handlers.Metrics.HealthyPlantsAmountHandler;

public interface IHealthyPlantsAmountHandler
{
    Task<List<AmountByMonthDto>> HandleAsync(HealthyPlantsAmountHandlerRequest request);
}
