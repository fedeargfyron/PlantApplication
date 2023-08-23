using Domain.Dtos.ExternalServices;

namespace Domain.Interfaces.ExternalServices;

public interface IExternalPlantInformationGetterService
{
    Task<GetPlantInformationByNameResultDto> GetPlantInformationByName(string plantName);
}
