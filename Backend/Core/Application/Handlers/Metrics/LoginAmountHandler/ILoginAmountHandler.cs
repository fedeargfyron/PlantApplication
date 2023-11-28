using Domain.Dtos.Metrics;

namespace Application.Handlers.Metrics.LoginAmountHandler;

public interface ILoginAmountHandler
{
    Task<List<AmountByMonthDto>> HandleAsync(LoginAmountHandlerRequest request);
}
