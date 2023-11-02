using Domain.Dtos.WateringCalendar;
using Domain.Extensions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Security;
using Domain.Interfaces.Services;

namespace Application.Services;

public class WateringCalendarService : IWateringCalendarService
{
    private readonly IApplicationUser _applicationUser;
    private readonly IWateringDayRepository _wateringDayRepository;

    public WateringCalendarService(IApplicationUser applicationUser, IWateringDayRepository wateringDayRepository)
    {
        _applicationUser = applicationUser;
        _wateringDayRepository = wateringDayRepository;
    }

    public Task<List<GetPlantWithWateringDaysFromUserResultDto>> GetCurrentPlantWithWateringDaysFromUser()
    {
        var userId = _applicationUser.GetUserId();
        return _wateringDayRepository.GetCurrentWateringDaysFromUserAsync(userId);
    }

    public async Task CreateNewWateringDatesForUser(DateTime newMaximumCalculatedWateringDay)
    {
        var wateringDays = await GetCurrentPlantWithWateringDaysFromUser();
        var newEntities = wateringDays.GetNewMaximumWateringDayEntities(newMaximumCalculatedWateringDay);
        await _wateringDayRepository.AddEntities(newEntities);
    }
}
