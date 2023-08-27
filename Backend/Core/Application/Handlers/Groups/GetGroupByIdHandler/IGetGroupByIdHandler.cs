using Domain.Entities;

namespace Application.Handlers.Groups.GetGroupByIdHandler;

public interface IGetGroupByIdHandler
{
    ValueTask<Group> HandleAsync(GetGroupByIdHandlerRequest request);
}
