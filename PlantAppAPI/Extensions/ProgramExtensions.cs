using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using PlantAppAPI.Endpoints.Plants;
using System.Diagnostics.CodeAnalysis;

namespace PlantAppAPI.Extensions;

[ExcludeFromCodeCoverage]
public static class ProgramExtensions
{
    public static void ConfigureWebApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddInfrastructureConfiguration(builder.Configuration)
            .AddCoreServices(builder.Configuration);
    }

    public static void ConfigureWebApplication(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Context>();
        context.Database.Migrate();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.RegisterPlantAPIs();

        app.UseHttpsRedirection();
    }
}