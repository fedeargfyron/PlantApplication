using Domain.Dtos.WateringCalendar;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IWateringDayRepository : IBaseRepository<WateringDay>
{
    Task<List<GetWateringDayFromUserResultDto>> GetCurrentWateringDaysFromUserAsync(int userId);
    Task AddEntities(List<WateringDay> entities);
}
