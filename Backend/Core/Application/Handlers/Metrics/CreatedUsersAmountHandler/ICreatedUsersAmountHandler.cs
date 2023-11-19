using Domain.Dtos.Metrics;

namespace Application.Handlers.Metrics.CreatedUsersAmountHandler;

public interface ICreatedUsersAmountHandler
{
    Task<List<AmountByMonthDto>> HandleAsync(CreatedUsersAmountHandlerRequest request);
}