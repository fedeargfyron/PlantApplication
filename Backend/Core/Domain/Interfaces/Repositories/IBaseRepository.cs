namespace Domain.Interfaces.Repositories;

public interface IBaseRepository<T>
{
    Task<List<T>> GetAllAsync();
    void Add(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
