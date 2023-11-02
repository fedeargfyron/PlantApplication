using Domain.Dtos.WateringCalendar;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WateringDayRepository : BaseRepository<WateringDay>, IWateringDayRepository
{
    public WateringDayRepository(Context context) : base(context)
    {
    }

    public Task AddEntities(List<WateringDay> entities)
    {
        _context.AddRange(entities);
        return _context.SaveChangesAsync();
    }

    public Task<List<GetPlantWithWateringDaysFromUserResultDto>> GetCurrentWateringDaysFromUserAsync(int userId)
    {
        //TODO: Save in cache current
        var today = DateTime.Today;

        return _context.Plants.Where(x => x.UserId == userId)
            .Select(x => new GetPlantWithWateringDaysFromUserResultDto()
            {
                Id = x.Id,
                WateringDaysFrequency = x.WateringDaysFrequency,
                ImageLink = x.ImageLink,
                Name = x.Name,
                ScientificName = x.ScientificName,
                Outside = x.Outside,
                WateringSpecificDates = x.WateringDays.Where(w => w.Day.Year == today.Year && w.Day.Month >= today.Month)
                                            .Select(w => w.Day)
                                            .OrderBy(w => w)
                                            .ToList()
            }).ToListAsync();
    }
}
