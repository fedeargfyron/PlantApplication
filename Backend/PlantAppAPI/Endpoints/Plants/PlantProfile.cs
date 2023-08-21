using AutoMapper;
using Domain.Dtos.Plants;
using Domain.Entities;
using PlantAppAPI.Endpoints.Plants.Contracts.Request;
using PlantAppAPI.Endpoints.Plants.Contracts.Response;

namespace PlantAppAPI.Endpoints.Plants;

public class PlantProfile : Profile
{
    public PlantProfile()
    {
        CreateMap<Plant, GetPlantResponse>();
        CreateMap<PostPlantRequest, PlantDto>();
        CreateMap<PutPlantRequest, UpdatePlantDto>();
        CreateMap<PlantDto, Plant>()
            .ReverseMap();
    }
}
