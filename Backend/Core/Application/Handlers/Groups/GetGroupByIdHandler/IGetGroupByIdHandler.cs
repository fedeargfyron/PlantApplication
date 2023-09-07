using Domain.Dtos.Groups;
using Domain.Entities;

namespace Application.Handlers.Groups.GetGroupByIdHandler;

public interface IGetGroupByIdHandler
{
    ValueTask<GetGroupByIdResultDto> HandleAsync(GetGroupByIdHandlerRequest request);
}
