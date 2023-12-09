using Domain.Dtos.Metrics;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Strategies.MetricsGetter;

namespace Application.Strategies.MetricsGetter;

public class CreatedUsersGetter : IMetricGetter
{
    private readonly IUserRepository _userRepository;

    public MetricType Type => MetricType.CreatedUsers;

    public CreatedUsersGetter(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<List<AmountByMonthDto>> Execute()
        => _userRepository.GetCreatedUsersAmountByMonthAsync();
}
