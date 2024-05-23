using Core;
using Core.Entities;

namespace Application.Services;

public interface IAppointmentService
{
    Task<IPagedList<Appointment>> SearchAppointmentsAsync(int pageindex = 0, int pageSize = int.MaxValue, string procedureName = null);
    Task AddAsync(Appointment appointment);
}