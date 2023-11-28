using Application;
using Infrastructure;
using Infrastructure.ExternalServices.PlantNet;
using Infrastructure.Options;
using Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlantAppAPI.Actions;
using PlantAppAPI.Endpoints.Groups;
using PlantAppAPI.Endpoints.Metrics;
using PlantAppAPI.Endpoints.Plants;
using PlantAppAPI.Endpoints.Security;
using PlantAppAPI.Endpoints.Users;
using PlantAppAPI.Endpoints.WateringCalendar;
using Serilog;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PlantAppAPI.Extensions;

[ExcludeFromCodeCoverage]
public static class ProgramExtensions
{
    public static void ConfigureWebApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
        {
            loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
            loggerConfiguration.Enrich.FromLogContext();
        });
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddInfrastructureConfiguration(builder.Configuration)
            .AddCoreServices(builder.Configuration);

        builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
        {
            builder.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader();

        }));

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]!)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        builder.Services.AddAuthorization(options =>
        {
            var context = builder.Services.BuildServiceProvider()
                       .GetService<Context>();

            foreach (var permission in context!.Permissions)
            {
                options.AddPolicy(permission.Value.ToString(),
                    policy => policy.Requirements.Add(new PermissionRequirement(permission.Value)));
            }
        });

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

        app.UseCors("corsapp");
        app.RegisterPlantAPIs();
        app.RegisterSecurityAPIs();
        app.RegisterUserAPIs();
        app.RegisterMetricAPIs();
        app.RegisterGroupAPIs();
        app.RegisterPermissionAPIs();
        app.RegisterWateringCalendarAPIs();
        app.UseHttpsRedirection();
    }
}