using Application.Handlers.Groups.AddGroupHandler;
using AutoMapper;
using Domain.Entities;
using PlantAppAPI.Endpoints.Groups.Contracts.Request;
using PlantAppAPI.Endpoints.Groups.Contracts.Response;

namespace PlantAppAPI.Endpoints.Users;

public class UserEndpointProfile : Profile
{
    public UserEndpointProfile()
    {
        CreateMap<Group, GetAllGroupsResponse>()
            .ReverseMap();

        CreateMap<AddGroupRequest, AddGroupHandlerRequest>();
    }
}
