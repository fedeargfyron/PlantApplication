using AutoMapper;
using Domain.Dtos.Users;
using Domain.Interfaces.Services;

namespace Application.Handlers.Users.UpdateUserHandler;

public class UpdateUserHandler : IUpdateUserHandler
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    public Task HandleAsync(UpdateUserHandlerRequest request)
        => _userService.UpdateUserAsync(_mapper.Map<UpdateUserDto>(request));
}
