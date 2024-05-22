using Core.Entities;

namespace Infrastructure.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> Table { get; }
    Task<IList<T>> GetAllAsync();
    Task<List<T>> GetByIdsAsync(ICollection<int> ids); 
    Task<T> GetByIdAsync(object id); 
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}