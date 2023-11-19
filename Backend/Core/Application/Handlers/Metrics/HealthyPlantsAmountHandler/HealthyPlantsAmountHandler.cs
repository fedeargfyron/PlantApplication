using Domain.Dtos.Metrics;
using Domain.Interfaces.Services;

namespace Application.Handlers.Metrics.HealthyPlantsAmountHandler;

public class HealthyPlantsAmountHandler : IHealthyPlantsAmountHandler
{
    private readonly IMetricsService _metricsService;

    public HealthyPlantsAmountHandler(IMetricsService metricsService)
    {
        _metricsService = metricsService;
    }

    public Task<List<AmountByMonthDto>> HandleAsync(HealthyPlantsAmountHandlerRequest request)
        => _metricsService.GetHealthyPlantsAmountAsync();
}
