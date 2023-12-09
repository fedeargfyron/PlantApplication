using Domain.Enums;
using Domain.Interfaces.Strategies.MetricsGetter;

namespace Application.Strategies.MetricsGetter;

public class MetricsGetterFactory : IMetricsGetterFactory
{
    private readonly IEnumerable<IMetricGetter> _strategies;

    public MetricsGetterFactory(IEnumerable<IMetricGetter> strategies)
    {
        _strategies = strategies;
    }

    public IMetricGetter CreateMetricsGetter(MetricType type)
    {
        var strategy = _strategies.SingleOrDefault(x => x.Type == type);
        if (strategy == null)
        {
            throw new ArgumentException("Missing strategy of metrics getter");
        }
        return strategy;
    }
}
