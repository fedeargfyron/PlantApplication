using Domain.Dtos.WateringCalendar;

namespace Domain.Interfaces.Services;

public interface IWateringCalendarService
{
    Task<List<GetPlantWithWateringDaysFromUserResultDto>> GetCurrentPlantWithWateringDaysFromUser();

    Task CreateNewWateringDatesForUser(DateTime newMaximumCalculatedWateringDay);
}