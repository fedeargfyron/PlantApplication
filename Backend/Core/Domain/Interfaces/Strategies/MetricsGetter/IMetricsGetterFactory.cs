using Domain.Enums;

namespace Domain.Interfaces.Strategies.MetricsGetter;

public interface IMetricsGetterFactory
{
    IMetricGetter CreateMetricsGetter(MetricType type);
}
