using Domain.Dtos.Groups;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastuctureTests.Repositories;

public class GroupRepositoryTests : IDisposable
{
    private Context _context;
    private GroupRepository _repo;
    public GroupRepositoryTests()
    {
        var dbContextOptions = new DbContextOptionsBuilder<Context>().Options;
        _context = new InMemoryContextTests(dbContextOptions, "GroupRepositoryTests");
        _repo = new(_context);
    }

    [Fact]
    public async Task UpdateAsync_WhenGroupDoesntExists_ReturnsException()
    {
        // Arrange
        var dto = new UpdateGroupDto(2, "Grupo 2", "", new(), new());


        // Act
        var actual = () => _repo.UpdateAsync(dto);

        // Assert
        await Assert.ThrowsAsync<ArgumentException>(actual);
    }

    [Fact]
    public async Task UpdateAsync_WhenGroupExists_ReturnSuccess()
    {
        // Arrange
        var group = new Group()
        {
            Id = 1,
            Name = "Grupo 1",
            Description = ""
        };
        _context.Add(group);
        _context.SaveChanges();

        var dto = new UpdateGroupDto(1, "Grupo 1 update", "update",
            new(),
            new());

        var expected = new Group()
        {
            Id = 1,
            Name = "Grupo 1 update",
            Description = "update"
        };

        // Act
        await _repo.UpdateAsync(dto);
        var actual = _context.Groups.First(x => x.Id == 1);

        // Assert
        Assert.True(GroupRepositoryTestsHelper.Validate(expected, actual));
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed && disposing)
        {
            _context.Dispose();
        }
        disposed = true;
    }
}
