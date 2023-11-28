using Domain.Dtos.Metrics;

namespace Domain.Interfaces.Repositories;

public interface ILogRepository
{
    Task<List<AmountByMonthDto>> GetLoginAmountByMonthAsync();
}
