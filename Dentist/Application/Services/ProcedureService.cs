using Application.Extensions;
using Core;
using Core.Entities;
using Infrastructure.Repositories;

namespace Application.Services;

public class ProcedureService : IProcedureService
{
    private readonly IRepository<Procedure> _procedureRepository;

    public ProcedureService(
        IRepository<Procedure> procedureRepository)
    {
        _procedureRepository = procedureRepository;
    }

    public async Task<IPagedList<Procedure>> GetAllProcedures()
    {
        return await (await _procedureRepository.GetAllAsync()).ToPagedListAsync(0, int.MaxValue);
    }

    public async Task<List<Procedure>> GetProceduresByIdsAsync(ICollection<int> ids)
    {
        return await _procedureRepository.GetByIdsAsync(ids);
    }

    public async Task AddAsync(Procedure procedure)
    {
        await _procedureRepository.InsertAsync(procedure);
    }

    public async Task<Procedure> GetProcedureByIdAsync(int id)
    {
        return await _procedureRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Procedure procedure)
    {
        await _procedureRepository.UpdateAsync(procedure);
    }

    public async Task DeleteAsync(Procedure procedure)
    {
        await _procedureRepository.DeleteAsync(procedure);
    }
}