using AutoMapper;
using Domain.Dtos.Users;
using Domain.Interfaces.Services;

namespace Application.Handlers.Users.AddUserHandler;

public class AddUserHandler : IAddUserHandler
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AddUserHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    public Task HandleAsync(AddUserHandlerRequest request)
        => _userService.AddUserAsync(_mapper.Map<AddUserHandlerRequest, AddUserDto>(request));
}
