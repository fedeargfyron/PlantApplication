using Domain.Dtos.Metrics;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class MetricsService : IMetricsService
{
    private readonly IUserRepository _userRepository;
    private readonly IHealthAssesmentRepository _healthAssesmentRepository;
    private readonly ILogRepository _logRepository;

    public MetricsService(IUserRepository userRepository, IHealthAssesmentRepository healthAssesmentRepository, ILogRepository logRepository)
    {
        _userRepository = userRepository;
        _healthAssesmentRepository = healthAssesmentRepository;
        _logRepository = logRepository;
    }

    public Task<List<AmountByMonthDto>> GetCreatedUsersAmountAsync()
        => _userRepository.GetCreatedUsersAmountByMonthAsync();

    public Task<List<AmountByMonthDto>> GetHealthyPlantsAmountAsync()
        => _healthAssesmentRepository.GetHealthyPlantsAmountByMonthAsync();

    public Task<List<AmountByMonthDto>> GetLoginAmountAsync()
        => _logRepository.GetLoginAmountByMonthAsync();

    public Task<List<AmountByMonthDto>> GetScansAmountAsync()
        => _healthAssesmentRepository.GetScansAmountByMonthAsync();
}
