using Core.Entities;

namespace Application.Services;

public interface IDoctorProcedureService
{
    Task<List<DoctorProcedure>> GetAllDoctorProceduresByDoctorIdAsync(int doctorId);
    Task<DoctorProcedure> GetDoctorProcedureByDoctorAndProcedureIdAsync(int doctorId, int procedureId);
    Task AddAsync(DoctorProcedure doctorProcedure);
    Task DeleteAsync(DoctorProcedure doctorProcedure);
}