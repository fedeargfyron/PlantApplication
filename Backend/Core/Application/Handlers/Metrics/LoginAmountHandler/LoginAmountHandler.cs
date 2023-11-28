using Domain.Dtos.Metrics;
using Domain.Interfaces.Services;

namespace Application.Handlers.Metrics.LoginAmountHandler;

public class LoginAmountHandler : ILoginAmountHandler
{
    private readonly IMetricsService _metricsService;

    public LoginAmountHandler(IMetricsService metricsService)
    {
        _metricsService = metricsService;
    }

    public Task<List<AmountByMonthDto>> HandleAsync(LoginAmountHandlerRequest request)
        => _metricsService.GetLoginAmountAsync();
}
