using Core;
using Core.Entities;

namespace Application.Services;

public interface IProcedureService
{
    Task<IPagedList<Procedure>> GetAllProcedures();
    Task<List<Procedure>> GetProceduresByIdsAsync(ICollection<int> ids);
    Task AddAsync(Procedure procedure);
    Task<Procedure> GetProcedureByIdAsync(int id);
    Task UpdateAsync(Procedure procedure);
    Task DeleteAsync(Procedure procedure);
}