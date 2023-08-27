using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly Context _context;

    public BaseRepository(Context context)
    {
        _context = context;
    }

    public ValueTask<T?> GetByIdAsync(int id) 
        => _context.Set<T>().FindAsync(id);

    public Task<List<T>> GetAllAsync()
        => _context.Set<T>().ToListAsync();

    public virtual async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
        => _context.Set<T>().Remove(entity);

    public Task SaveChangesAsync()
        => _context.SaveChangesAsync();
}
