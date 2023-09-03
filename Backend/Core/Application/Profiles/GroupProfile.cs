using Application.Handlers.Groups.AddGroupHandler;
using Application.Handlers.Groups.UpdateGroupHandler;
using AutoMapper;
using Domain.Dtos.Groups;
using Domain.Entities;

namespace Application.Profiles;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<AddGroupHandlerRequest, AddGroupDto>();
        CreateMap<UpdateGroupHandlerRequest, UpdateGroupDto>();
        CreateMap<AddGroupDto, Group>()
            .ForMember(dest => 
                dest.Permissions,
                opt => opt.MapFrom(src =>
                src.PermissionsIds.Select(x => new Permission() { Id = x }).ToList()))
            .ForMember(dest => 
                dest.Users,
                opt => opt.MapFrom(src =>
                src.UsersIds.Select(x => new User() { Id = x }).ToList()));
    }
}
