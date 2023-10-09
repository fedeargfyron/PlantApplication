using AutoMapper;
using Domain.Dtos.ExternalServices.HealthAssesment;
using Infrastructure.ExternalServices.PlantId.Response.HealthAssesmentResponse;

namespace Infrastructure.ExternalServices.PlantId;

public class PlantIdProfile : Profile
{
    public PlantIdProfile()
    {
        CreateMap<GetPlantHealthAssesmentResponse, HealthAssesmentResultDto>();
        CreateMap<PlantIdResult, AssesmentResultDto>();
        CreateMap<IsHealthy, IsHealthyDto>();
        CreateMap<Disease, DiseaseDto>();
        CreateMap<DiseaseSuggestion, DiseaseSuggestionDto>();
        CreateMap<SimilarImage, SimilarImageDto>();
        CreateMap<Details, DetailsDto>();
    }
}
