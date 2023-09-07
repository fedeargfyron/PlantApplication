namespace Domain.Interfaces.Repositories;

public interface IBaseRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
