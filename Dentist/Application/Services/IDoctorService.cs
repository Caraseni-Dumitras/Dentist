using Core;
using Core.Entities;

namespace Application.Services;

public interface IDoctorService
{
    Task<IPagedList<Doctor>> GetAllDoctors();
}