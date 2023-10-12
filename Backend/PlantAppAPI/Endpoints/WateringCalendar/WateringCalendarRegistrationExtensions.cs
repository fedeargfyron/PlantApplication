using Application.Handlers.WateringCalendar.GetWateringDaysFromUserHandler;
using Microsoft.AspNetCore.Mvc;

namespace PlantAppAPI.Endpoints.WateringCalendar;

public static class WateringCalendarRegistrationExtensions
{
    public static void RegisterWateringCalendarAPIs(this WebApplication app)
    {
        var users = app.MapGroup("/wateringcalendar");

        users.MapGet("/", async ([FromQuery] bool? addWateringMonth, IGetWateringDaysFromUserHandler handler) =>
        {
            var result = await handler.HandleAsync(new(addWateringMonth));
            return TypedResults.Ok(result);
        }).RequireAuthorization();
    }
}
