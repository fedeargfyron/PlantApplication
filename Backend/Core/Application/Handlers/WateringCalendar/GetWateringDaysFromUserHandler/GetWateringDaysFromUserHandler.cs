using Application.Services;
using Domain.Dtos.WateringCalendar;
using Domain.Interfaces.Security;
using Domain.Interfaces.Services;

namespace Application.Handlers.WateringCalendar.GetWateringDaysFromUserHandler;

public class GetWateringDaysFromUserHandler : IGetWateringDaysFromUserHandler
{
    private readonly IWateringCalendarService _wateringCalendarService;
    private readonly IApplicationUser _applicationUser;
    private readonly IUserService _userService;

    public GetWateringDaysFromUserHandler(IWateringCalendarService wateringCalendarService, IApplicationUser applicationUser, IUserService userService)
    {
        _wateringCalendarService = wateringCalendarService;
        _applicationUser = applicationUser;
        _userService = userService;
    }
    public async Task<List<GetPlantWithWateringDaysFromUserResultDto>> HandleAsync(GetWateringDaysFromUserHandlerRequest request)
    {
        var maximumCalculatedWateringDay = await _applicationUser.GetUserMaximumCalculatedWateringDayAsync();
        if (maximumCalculatedWateringDay < DateTime.Today.AddDays(14) || request.ShouldAddWateringMonth == true)
        {
            await CreateNewWateringDatesForUser(maximumCalculatedWateringDay);
        }

        return await _wateringCalendarService.GetCurrentPlantWithWateringDaysFromUser();
    }

    private async Task CreateNewWateringDatesForUser(DateTime maximumCalculatedWateringDay)
    {
        var newMaximumWateringDate = maximumCalculatedWateringDay.AddMonths(1);
        await _wateringCalendarService.CreateNewWateringDatesForUser(newMaximumWateringDate);
        await _userService.UpdateUserMaximumWateringDate(newMaximumWateringDate);
    }
}
