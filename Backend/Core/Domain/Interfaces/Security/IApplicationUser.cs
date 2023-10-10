namespace Domain.Interfaces.Security;

public interface IApplicationUser
{
    int GetUserId();
    DateTime GetUserMaximumCalculatedWateringDay();
}
