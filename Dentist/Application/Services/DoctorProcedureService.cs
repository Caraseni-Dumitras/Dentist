using Core.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class DoctorProcedureService : IDoctorProcedureService
{
    private readonly IRepository<DoctorProcedure> _doctorProcedureRepository;

    public DoctorProcedureService(
        IRepository<DoctorProcedure> doctorProcedureRepository)
    {
        _doctorProcedureRepository = doctorProcedureRepository;
    }

    public async Task<DoctorProcedure> GetDoctorProcedureByDoctorAndProcedureIdAsync(int doctorId, int procedureId)
    {
        return await _doctorProcedureRepository.Table.FirstOrDefaultAsync(it => it.DoctorId == doctorId && it.ProcedureId == procedureId);
    }

    public async Task AddAsync(DoctorProcedure doctorProcedure)
    {
        await _doctorProcedureRepository.InsertAsync(doctorProcedure);
    }

    public async Task<List<DoctorProcedure>> GetAllDoctorProceduresByDoctorIdAsync(int doctorId)
    {
        return await _doctorProcedureRepository.Table.Where(it => it.DoctorId == doctorId).ToListAsync();
    }

    public async Task DeleteAsync(DoctorProcedure doctorProcedure)
    {
        await _doctorProcedureRepository.DeleteAsync(doctorProcedure);
    }
}