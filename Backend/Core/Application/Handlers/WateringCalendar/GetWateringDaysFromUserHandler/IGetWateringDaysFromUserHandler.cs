using Domain.Dtos.WateringCalendar;

namespace Application.Handlers.WateringCalendar.GetWateringDaysFromUserHandler;

public interface IGetWateringDaysFromUserHandler
{
    Task<List<GetPlantWithWateringDaysFromUserResultDto>> HandleAsync(GetWateringDaysFromUserHandlerRequest request);
}
