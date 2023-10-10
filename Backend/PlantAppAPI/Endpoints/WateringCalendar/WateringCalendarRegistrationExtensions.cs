using Application.Handlers.WateringCalendar.GetWateringDaysFromUserHandler;

namespace PlantAppAPI.Endpoints.WateringCalendar;

public static class WateringCalendarRegistrationExtensions
{
    public static void RegisterWateringCalendarAPIs(this WebApplication app)
    {
        var users = app.MapGroup("/wateringcalendar");

        users.MapGet("/", async (IGetWateringDaysFromUserHandler handler) =>
        {
            var result = await handler.HandleAsync(new());
            return TypedResults.Ok(result);
        }).RequireAuthorization();
    }
}
