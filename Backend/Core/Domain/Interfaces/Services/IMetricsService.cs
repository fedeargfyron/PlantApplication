using Domain.Dtos.Metrics;

namespace Domain.Interfaces.Services;

public interface IMetricsService
{
    Task<List<AmountByMonthDto>> GetScansAmountAsync();
    Task<List<AmountByMonthDto>> GetHealthyPlantsAmountAsync();
    Task<List<AmountByMonthDto>> GetCreatedUsersAmountAsync();
    Task<List<AmountByMonthDto>> GetLoginAmountAsync();
}
