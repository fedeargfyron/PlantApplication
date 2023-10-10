using Domain.Dtos.WateringCalendar;
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

    public async Task<List<GetWateringDayFromUserResultDto>> GetCurrentWateringDaysFromUser()
    {
        var userId = _applicationUser.GetUserId();
        var wateringDays = await _wateringDayRepository.GetCurrentWateringDaysFromUser(userId);

        var maximumCalculatedWateringDay = _applicationUser.GetUserMaximumCalculatedWateringDay();
        if (maximumCalculatedWateringDay < DateTime.Today.AddDays(7))
        {
            wateringDays.AddRange(await CreateAndGetWateringMonthOfUser());
        }

        return wateringDays;
    }

    public Task<List<GetWateringDayFromUserResultDto>> CreateAndGetWateringMonthOfUser()
    {
        var userId = _applicationUser.GetUserId();
        var maximumCalculatedWateringDay = _applicationUser.GetUserMaximumCalculatedWateringDay();
        return _wateringDayRepository.CreateAndGetWateringMonthOfUser(userId, maximumCalculatedWateringDay);
    }
}
