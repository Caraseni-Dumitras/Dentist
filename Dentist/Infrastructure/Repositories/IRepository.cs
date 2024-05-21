using Core.Entities;

namespace Infrastructure.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<IList<T>> GetAllAsync();
    Task<T> GetByIdAsync(object id); 
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}