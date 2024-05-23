using Core;
using Core.Entities;

namespace Application.Services;

public interface IDoctorService
{
    Task<IPagedList<Doctor>> GetAllDoctors();
    Task<List<Doctor>> GetAllDoctorsByProcedureId(int procedureId);
    Task AddAsync(Doctor doctor);
    Task<Doctor> GetDoctorByIdAsync(int id);
    Task UpdateAsync(Doctor doctor);
    Task DeleteAsync(Doctor doctor);
}