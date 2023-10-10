using Domain.Dtos.WateringCalendar;

namespace Domain.Interfaces.Repositories;

public interface IWateringDayRepository
{
    Task<List<GetWateringDayFromUserResultDto>> GetCurrentWateringDaysFromUser(int userId);
    Task<List<GetWateringDayFromUserResultDto>> CreateAndGetWateringMonthOfUser(int userId, DateTime maximumCalculatedWateringDay);
}
