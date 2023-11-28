using Domain.Constants;
using Domain.Dtos.Metrics;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Infrastructure.Repositories;

public class LogRepository : ILogRepository
{
    private readonly Context _context;

    public LogRepository(Context context)
    {
        _context = context;
    }

    public Task<List<AmountByMonthDto>> GetLoginAmountByMonthAsync()
        => _context.Logs.Where(x => x.Origin == LogOriginConstants.Login)
            .GroupBy(x => new { x.TimeStamp.Year, x.TimeStamp.Month })
            .Select(x => new AmountByMonthDto(DateTime.ParseExact($"{x.Key.Year}/{x.Key.Month}", "yyyy/M", CultureInfo.InvariantCulture), x.Count()))
            .ToListAsync();
}
