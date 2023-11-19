using Domain.Dtos.Metrics;

namespace Application.Handlers.Metrics.ScansAmountHandler;

public interface IScansAmountHandler
{
    Task<List<AmountByMonthDto>> HandleAsync(ScansAmountHandlerRequest request);
}
