using Application;
using Infrastructure;
using Infrastructure.ExternalServices.ImageKit;
using Microsoft.EntityFrameworkCore;
using PlantAppAPI.Endpoints.Plants;
using System.Diagnostics.CodeAnalysis;
using Imagekit;
using Imagekit.Sdk;
using Microsoft.Extensions.Options;
using Infrastructure.Options;
using Infrastructure.ExternalServices.PlantNet;
using Microsoft.Extensions.DependencyInjection;

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

        builder.Services.AddHttpClient<ExternalPlantNetService>((serviceProvider, httpClient) =>
        {
            var plantNetOptions = serviceProvider.GetRequiredService<IOptions<PlantNetOptions>>().Value;
            httpClient.BaseAddress = new Uri(plantNetOptions.BaseUrl);
        });
        
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