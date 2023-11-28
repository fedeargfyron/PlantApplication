using Domain.Entities;
using Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Infrastructure;

public class Context : DbContext
{
    private readonly ConnectionStringsOptions _options;
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WateringDay> WateringDays { get; set; }
    public DbSet<PlantRisk> PlantRisks { get; set; }
    public DbSet<HealthAssesment> HealthAssesments { get; set; }
    public DbSet<Log> Logs { get; set; }

    public Context(DbContextOptions<Context> options, IOptions<ConnectionStringsOptions> connectionOptions) : base(options)
    {
        _options = connectionOptions.Value;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_options.PlantApp);
        base.OnConfiguring(optionsBuilder);
    }
}
