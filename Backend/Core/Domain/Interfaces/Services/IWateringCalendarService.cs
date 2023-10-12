using Domain.Dtos.WateringCalendar;

namespace Domain.Interfaces.Services;

public interface IWateringCalendarService
{
    Task<List<GetWateringDayFromUserResultDto>> GetCurrentWateringDaysFromUser();

    Task CreateNewWateringDatesForUser(DateTime newMaximumCalculatedWateringDay);
}