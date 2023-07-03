namespace PlantAppAPI.Endpoints.Plants;

public static class PlantRegistrationExtensions
{
    public static void RegisterPlantAPIs(this WebApplication app)
    {
        var plants = app.MapGroup("/plants");

        plants.MapGet("/", async () => { });
    }
}
