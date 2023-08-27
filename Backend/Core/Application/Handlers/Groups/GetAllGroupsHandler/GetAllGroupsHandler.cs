using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Handlers.Groups.GetAllGroupsHandler;

public class GetAllGroupsHandler : IGetAllGroupsHandler
{
    private readonly IGroupService _groupService;

    public GetAllGroupsHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }
    public Task<List<Group>> HandleAsync(GetAllGroupsHandlerRequest request)
        => _groupService.GetAllAsync();
}
