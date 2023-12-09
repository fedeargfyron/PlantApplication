using Domain.Dtos.Metrics;
using Domain.Enums;
using Domain.Interfaces.Services;
using Domain.Interfaces.Strategies.MetricsGetter;

namespace Application.Services;

public class MetricsService : IMetricsService
{
    private readonly IMetricsGetterFactory _metricsGetterFactory;
    public MetricsService(IMetricsGetterFactory metricsGetterFactory)
    {
        _metricsGetterFactory = metricsGetterFactory;
    }

    public Task<List<AmountByMonthDto>> GetCreatedUsersAmountAsync()
        => _metricsGetterFactory.CreateMetricsGetter(MetricType.CreatedUsers).Execute();

    public Task<List<AmountByMonthDto>> GetHealthyPlantsAmountAsync()
        => _metricsGetterFactory.CreateMetricsGetter(MetricType.HealthyPlants).Execute();

    public Task<List<AmountByMonthDto>> GetLoginAmountAsync()
        => _metricsGetterFactory.CreateMetricsGetter(MetricType.Logins).Execute();

    public Task<List<AmountByMonthDto>> GetScansAmountAsync() 
        => _metricsGetterFactory.CreateMetricsGetter(MetricType.Scans).Execute();

}
