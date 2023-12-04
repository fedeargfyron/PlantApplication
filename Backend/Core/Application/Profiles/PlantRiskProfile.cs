using Application.Handlers.Users.AddUserHandler;
using AutoMapper;
using Domain.Dtos.PlantRisks;
using Domain.Dtos.Users;
using Domain.Entities;

namespace Application.Profiles;

public class PlantRiskProfile : Profile
{
    public PlantRiskProfile()
    {
        CreateMap<PlantRisk, TodayRisksByPlantResultDto>()
            .ReverseMap();
    }
}
