using Core.Entities;

namespace Application.Services;

public interface IAppointmentService
{
    Task AddAsync(Appointment appointment);
}