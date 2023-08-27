using Domain.Entities;

namespace Application.Handlers.Groups.GetAllGroupsHandler;

public interface IGetAllGroupsHandler
{
    Task<List<Group>> HandleAsync(GetAllGroupsHandlerRequest request);
}
