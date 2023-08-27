using AutoMapper;
using Domain.Dtos.Groups;
using Domain.Interfaces.Services;

namespace Application.Handlers.Groups.AddGroupHandler;

public class AddGroupHandler : IAddGroupHandler
{
    private readonly IGroupService _groupService;
    private readonly IMapper _mapper;

    public AddGroupHandler(IGroupService groupService, IMapper mapper)
    {
        _groupService = groupService;
        _mapper = mapper;
    }

    public Task HandleAsync(AddGroupHandlerRequest request)
        => _groupService.AddGroupAsync(_mapper.Map<AddGroupDto>(request));
}
