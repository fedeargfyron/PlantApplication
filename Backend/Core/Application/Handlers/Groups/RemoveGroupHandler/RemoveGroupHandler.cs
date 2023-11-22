using Domain.Interfaces.Services;

namespace Application.Handlers.Groups.RemoveGroupHandler;

public class RemoveGroupHandler : IRemoveGroupHandler
{
    private readonly IGroupService _groupService;

    public RemoveGroupHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }
    public Task HandleAsync(RemoveGroupHandlerRequest request)
        => _groupService.DeleteGroupByIdAsync(request.Id);
}
