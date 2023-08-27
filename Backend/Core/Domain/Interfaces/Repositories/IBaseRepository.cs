namespace Domain.Interfaces.Repositories;

public interface IBaseRepository<T>
{
    ValueTask<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
