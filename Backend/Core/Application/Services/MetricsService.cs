using Domain.Dtos.Metrics;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class MetricsService : IMetricsService
{
    private readonly IUserRepository _userRepository;
    private readonly IHealthAssesmentRepository _healthAssesmentRepository;

    public MetricsService(IUserRepository userRepository, IHealthAssesmentRepository healthAssesmentRepository)
    {
        _userRepository = userRepository;
        _healthAssesmentRepository = healthAssesmentRepository;
    }

    public Task<List<AmountByMonthDto>> GetCreatedUsersAmountAsync()
        => _userRepository.GetCreatedUsersAmountByMonthAsync();

    public Task<List<AmountByMonthDto>> GetHealthyPlantsAmountAsync()
        => _healthAssesmentRepository.GetHealthyPlantsAmountByMonthAsync();

    public Task<List<AmountByMonthDto>> GetScansAmountAsync()
        => _healthAssesmentRepository.GetScansAmountByMonthAsync();
}
