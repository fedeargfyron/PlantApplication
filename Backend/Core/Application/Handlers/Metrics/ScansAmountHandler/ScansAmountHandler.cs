using Domain.Dtos.Metrics;
using Domain.Interfaces.Services;

namespace Application.Handlers.Metrics.ScansAmountHandler;

public class ScansAmountHandler : IScansAmountHandler
{
    private readonly IMetricsService _metricsService;

    public ScansAmountHandler(IMetricsService metricsService)
    {
        _metricsService = metricsService;
    }
    public Task<List<AmountByMonthDto>> HandleAsync(ScansAmountHandlerRequest request)
        => _metricsService.GetScansAmountAsync();
}