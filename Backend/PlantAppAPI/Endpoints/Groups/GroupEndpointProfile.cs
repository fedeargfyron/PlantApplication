using Application.Handlers.Groups.AddGroupHandler;
using AutoMapper;
using Domain.Dtos.Groups;
using Domain.Entities;
using PlantAppAPI.Endpoints.Groups.Contracts.Request;
using PlantAppAPI.Endpoints.Groups.Contracts.Response;

namespace PlantAppAPI.Endpoints.Groups;

public class GroupEndpointProfile : Profile
{
    public GroupEndpointProfile()
    {
        CreateMap<Group, GetAllGroupsResponse>()
            .ReverseMap();

        CreateMap<AddGroupRequest, AddGroupHandlerRequest>();

        CreateMap<GetGroupByIdResultDto, GetGroupByIdResponse>();
    }
}
