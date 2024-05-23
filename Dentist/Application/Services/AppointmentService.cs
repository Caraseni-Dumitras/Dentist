using Core.Entities;
using Infrastructure.Repositories;

namespace Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IRepository<Appointment> _appointmentRepository;

    public AppointmentService(
        IRepository<Appointment> appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task AddAsync(Appointment appointment)
    {
        await _appointmentRepository.InsertAsync(appointment);
    }
}