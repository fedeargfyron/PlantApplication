﻿using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Handlers.Users.GetUserByIdHandler;

public class GetUserByIdHandler : IGetUserByIdHandler
{
    private readonly IUserService _userService;

    public GetUserByIdHandler(IUserService userService)
    {
        _userService = userService;
    }
    public ValueTask<User> HandleAsync(GetUserByIdHandlerRequest request)
        => _userService.GetUserByIdAsync(request.UserId);
}
