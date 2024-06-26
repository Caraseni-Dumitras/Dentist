﻿using Application.Extensions;
using Core;
using Core.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IRepository<Doctor> _doctorRepository;

    public DoctorService(
        IRepository<Doctor> doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<IPagedList<Doctor>> GetAllDoctors()
    {
        return await ( await _doctorRepository.GetAllAsync()).ToPagedListAsync(0, int.MaxValue);
    }

    public async Task<List<Doctor>> GetAllDoctorsByProcedureId(int procedureId, DateTime appointmentDateTimeUtc)
    {
        return await _doctorRepository.Table
            .Where(d => d.DoctorProcedures.Any(dp => dp.ProcedureId == procedureId)
                        && d.Appointments.All(a => a.Date != appointmentDateTimeUtc))
            .ToListAsync();
    }

    public async Task AddAsync(Doctor doctor)
    {
        await _doctorRepository.InsertAsync(doctor);
    }

    public async Task<Doctor> GetDoctorByIdAsync(int id)
    {
        return await _doctorRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        await _doctorRepository.UpdateAsync(doctor);
    }

    public async Task DeleteAsync(Doctor doctor)
    {
        await _doctorRepository.DeleteAsync(doctor);
    }
}