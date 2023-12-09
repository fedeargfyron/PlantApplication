using Domain.Dtos.Metrics;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Strategies.MetricsGetter;

namespace Application.Strategies.MetricsGetter;

public class LoginsGetter : IMetricGetter
{
    private readonly ILogRepository _logRepository;

    public MetricType Type => MetricType.Logins;
    public LoginsGetter(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public Task<List<AmountByMonthDto>> Execute()
        => _logRepository.GetLoginAmountByMonthAsync();
}
