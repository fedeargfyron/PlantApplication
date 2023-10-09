using PlantAppAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureWebApplicationBuilder();

var app = builder.Build();
app.ConfigureWebApplication();
 
app.Run();


