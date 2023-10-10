using Domain.Dtos.WateringCalendar;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WateringDayRepository : IWateringDayRepository
{
    private readonly Context _context;

    public WateringDayRepository(Context context)
    {
        _context = context;
    }

    public Task<List<GetWateringDayFromUserResultDto>> CreateAndGetWateringMonthOfUser(int userId, DateTime maximumCalculatedWateringDay)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetWateringDayFromUserResultDto>> GetCurrentWateringDaysFromUser(int userId)
    {
        //TODO: Save in cache current
        var today = DateTime.Today;
        var results = _context.WateringDays.Where(x => x.Plant.UserId == userId && x.Day.Year == today.Year && x.Day.Month >= today.Month)
            .GroupBy(x => x.Day).Select(
                x => new GetWateringDayFromUserResultDto(
                    x.Key, 
                    x.Select(p => new WateringDayPlantDto(p.PlantId, p.Plant.WateringDaysFrequency, p.Plant.Name, p.Plant.ImageLink, p.Plant.Outside)).ToList()
                )).OrderBy(x => x.Day).ToListAsync();

        return results;
    }
}
