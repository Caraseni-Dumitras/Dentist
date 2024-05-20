using Core.Entities;

namespace Infrastructure.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<IList<T>> GetAll();
    Task<T> GetByIdAsync(object id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
}