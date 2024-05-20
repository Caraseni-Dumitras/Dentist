﻿using Application.Extensions;
using Core;
using Core.Entities;
using Infrastructure.Repositories;

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
        return await (await _doctorRepository.GetAll()).ToPagedListAsync(0, int.MaxValue);
    }
}