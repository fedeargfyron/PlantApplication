using AutoMapper;
using Domain.Dtos.Groups;
using Domain.Interfaces.Services;

namespace Application.Handlers.Groups.UpdateGroupHandler;

public class UpdateGroupHandler : IUpdateGroupHandler
{
    private readonly IGroupService _groupService;
    private readonly IMapper _mapper;

    public UpdateGroupHandler(IGroupService groupService, IMapper mapper)
    {
        _groupService = groupService;
        _mapper = mapper;
    }
    public Task HandleAsync(UpdateGroupHandlerRequest request)
        => _groupService.UpdateGroupAsync(_mapper.Map<UpdateGroupDto>(request));
}
