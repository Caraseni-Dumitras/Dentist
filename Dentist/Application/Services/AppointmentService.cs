using Application.Extensions;
using Core;
using Core.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IRepository<Appointment> _appointmentRepository;

    public AppointmentService(
        IRepository<Appointment> appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<IPagedList<Appointment>> SearchAppointmentsAsync(int pageindex = 0, int pageSize = int.MaxValue, string procedureName = null)
    {
        var query = _appointmentRepository.Table;

        if (!string.IsNullOrEmpty(procedureName))
        {
            query = query.Where(appointment =>
                appointment.Procedure.Name.ToLower().Contains(procedureName.ToLower()));
        }

        return await(await query.ToListAsync()).ToPagedListAsync(pageindex, pageSize);
    }

    public async Task AddAsync(Appointment appointment)
    {
        await _appointmentRepository.InsertAsync(appointment);
    }
}