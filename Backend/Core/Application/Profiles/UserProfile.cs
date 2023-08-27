using Application.Handlers.Users.AddUserHandler;
using Application.Handlers.Users.UpdateUserHandler;
using AutoMapper;
using Domain.Dtos.Users;
using Domain.Entities;

namespace Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<AddUserDto, User>()
            .ForMember(dest => dest.Groups, 
            opt => opt.MapFrom(src => 
                src.GroupsIds.Select(x => new Group() { Id = x } ).ToList()));

        CreateMap<AddUserHandlerRequest, AddUserDto>()
            .ReverseMap();
        CreateMap<UpdateUserHandlerRequest, UpdateUserDto>();
    }
}
