﻿using Domain.Entities;
using Domain.Enums;
using Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Infrastructure;

public class Context : DbContext
{
    private readonly ConnectionStringsOptions _options;
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Domain.Entities.Permission> Permissions { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
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
