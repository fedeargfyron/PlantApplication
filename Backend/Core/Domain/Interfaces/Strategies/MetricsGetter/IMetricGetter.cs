using Domain.Dtos.Metrics;
using Domain.Enums;

namespace Domain.Interfaces.Strategies.MetricsGetter;

public interface IMetricGetter
{
    MetricType Type { get; }
    Task<List<AmountByMonthDto>> Execute();
}
