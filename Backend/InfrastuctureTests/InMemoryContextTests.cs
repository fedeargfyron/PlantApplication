using Infrastructure;
using Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NSubstitute;

namespace InfrastuctureTests;

public class InMemoryContextTests : Context
{   
    private readonly string _databaseName;
    public InMemoryContextTests(DbContextOptions<Context> options, string databaseName) : base(options, Substitute.For<IOptions<ConnectionStringsOptions>>())
    {
        _databaseName = databaseName;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(_databaseName, b => b.EnableNullChecks(false));
    }
}