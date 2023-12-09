using Domain.Dtos.Metrics;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Strategies.MetricsGetter;

namespace Application.Strategies.MetricsGetter;

public class HealthyPlantsGetter : IMetricGetter
{
    private readonly IHealthAssesmentRepository _healthAssesmentRepository;

    public MetricType Type => MetricType.HealthyPlants;

    public HealthyPlantsGetter(IHealthAssesmentRepository healthAssesmentRepository)
    {
        _healthAssesmentRepository = healthAssesmentRepository;
    }
    public Task<List<AmountByMonthDto>> Execute()
        => _healthAssesmentRepository.GetHealthyPlantsAmountByMonthAsync();
}