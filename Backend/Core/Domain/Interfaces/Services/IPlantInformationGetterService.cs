using Domain.Dtos.ExternalServices;

namespace Domain.Interfaces.Services;

public interface IPlantInformationGetterService
{
    Task<GetPlantInformationByNameResultDto> GetPlantInformationByName(string plantName);
}
