using Domain.Dtos.WateringCalendar;
using Domain.Interfaces.Services;

namespace Application.Handlers.WateringCalendar.GetWateringDaysFromUserHandler;

public class GetWateringDaysFromUserHandler : IGetWateringDaysFromUserHandler
{
    private readonly IWateringCalendarService _wateringCalendarService;

    public GetWateringDaysFromUserHandler(IWateringCalendarService wateringCalendarService)
    {
        _wateringCalendarService = wateringCalendarService;
    }
    public Task<List<GetWateringDayFromUserResultDto>> HandleAsync(GetWateringDaysFromUserHandlerRequest request)
        => _wateringCalendarService.GetCurrentWateringDaysFromUser();
}
