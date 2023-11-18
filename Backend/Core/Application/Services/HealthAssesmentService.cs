using Domain.Dtos.ExternalServices.HealthAssesment;
using Domain.Dtos.Plants;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Security;
using Domain.Interfaces.Services;

namespace Application.Services;

public class HealthAssesmentService : IHealthAssesmentService
{
    private readonly IExternalHealthAssesmentService _externalHealthAssesmentService;
    private readonly IHealthAssesmentRepository _healthAssesmentRepository;
    private readonly IExternalImageUploaderService _externalImageUploaderService;
    private readonly IApplicationUser _applicationUser;

    public HealthAssesmentService(IExternalHealthAssesmentService externalHealthAssesmentService, 
        IHealthAssesmentRepository healthAssesmentRepository,
        IExternalImageUploaderService externalImageUploaderService,
        IApplicationUser applicationUser)
    {
        _externalHealthAssesmentService = externalHealthAssesmentService;
        _healthAssesmentRepository = healthAssesmentRepository;
        _externalImageUploaderService = externalImageUploaderService;
        _applicationUser = applicationUser;
    }

    public async Task<HealthAssesmentResultDto> DoHealthAssestment(DoHealthAssestmentRequestDto requestDto)
    {
        var result = await _externalHealthAssesmentService.DoHealthAssestment(requestDto);
        var disease = result.Result.Disease.Suggestions.First();
        var userId = _applicationUser.GetUserId();
        var imageUrl = await _externalImageUploaderService.UploadImageAsync(requestDto.Base64Image, requestDto.FileName);
        await _healthAssesmentRepository.AddAsync(new()
        {
            Disease = disease.Name,
            DiseaseCommonNames = string.Join(", ", disease.Details.CommonNames),
            DiseaseDescription = disease.Details.Description,
            DiseaseProbability = disease.Probability,
            IsHealthy = result.Result.IsHealthy.Result,
            IsHealthyProbability = result.Result.IsHealthy.Probability,
            PlantId = requestDto.PlantId,
            PlantImage = imageUrl,
            UserId = userId
        });

        return result;
    }

    public Task<GetHealthAssesmentByIdDto> GetHealthAssesmentByIdAsync(int id)
        => _healthAssesmentRepository.GetHealthAssesmentByIdAsync(id);

    public Task<List<GetHealthAssesmentDto>> GetHealthAssesmentsAsync()
    {
        var userId = _applicationUser.GetUserId();
        return _healthAssesmentRepository.GetAllAsync(userId);
    }
}
