namespace Domain.Interfaces.Security;

public interface IApplicationUser
{
    int GetUserId();
    Task<DateTime> GetUserMaximumCalculatedWateringDayAsync();
}
