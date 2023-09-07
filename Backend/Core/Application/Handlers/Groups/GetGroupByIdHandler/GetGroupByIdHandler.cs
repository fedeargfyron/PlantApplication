using Domain.Dtos.Groups;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Handlers.Groups.GetGroupByIdHandler;

public class GetGroupByIdHandler : IGetGroupByIdHandler
{
    private readonly IGroupService _groupService;

    public GetGroupByIdHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }
    public ValueTask<GetGroupByIdResultDto> HandleAsync(GetGroupByIdHandlerRequest request)
        => _groupService.GetGroupByIdAsync(request.Id);
}
