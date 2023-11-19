using Domain.Dtos.Metrics;
using Domain.Interfaces.Services;

namespace Application.Handlers.Metrics.CreatedUsersAmountHandler;

public class CreatedUsersAmountHandler : ICreatedUsersAmountHandler
{
    private readonly IMetricsService _metricsService;

    public CreatedUsersAmountHandler(IMetricsService metricsService)
    {
        _metricsService = metricsService;
    }

    public Task<List<AmountByMonthDto>> HandleAsync(CreatedUsersAmountHandlerRequest request)
        => _metricsService.GetCreatedUsersAmountAsync();
}
