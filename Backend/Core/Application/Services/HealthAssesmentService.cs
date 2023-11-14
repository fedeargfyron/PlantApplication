using Domain.Dtos.ExternalServices.HealthAssesment;
using Domain.Dtos.Plants;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class HealthAssesmentService : IHealthAssesmentService
{
    private readonly IExternalHealthAssesmentService _externalHealthAssesmentService;
    private readonly IHealthAssesmentRepository _healthAssesmentRepository;

    public HealthAssesmentService(IExternalHealthAssesmentService externalHealthAssesmentService, IHealthAssesmentRepository healthAssesmentRepository)
    {
        _externalHealthAssesmentService = externalHealthAssesmentService;
        _healthAssesmentRepository = healthAssesmentRepository;
    }

    public async Task<HealthAssesmentResultDto> DoHealthAssestment(DoHealthAssestmentRequestDto requestDto)
    {
        var result = await _externalHealthAssesmentService.DoHealthAssestment(requestDto);
        var disease = result.Result.Disease.Suggestions.First();
        await _healthAssesmentRepository.AddAsync(new()
        {
            Disease = disease.Name,
            DiseaseCommonNames = string.Join(", ", disease.Details.CommonNames),
            DiseaseDescription = disease.Details.Description,
            DiseaseProbability = disease.Probability,
            IsHealthy = result.Result.IsHealthy.Result,
            IsHealthyProbability = result.Result.IsHealthy.Probability,
            PlantId = requestDto.PlantId,
            PlantImage = requestDto.Base64Image
        });

        return result;
    }

    public Task<List<GetHealthAssesmentDto>> GetHealthAssesmentsAsync()
        => _healthAssesmentRepository.GetAllAsync();
}
