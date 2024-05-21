﻿using Application.Services;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.Models.DoctorModels;

namespace Web.Areas.Admin.Controllers;

public class DoctorController : AdminBaseController
{
    private readonly IDoctorModelFactory _doctorModelFactory;
    private readonly IMapper _mapper;
    private readonly IDoctorService _doctorService;

    public DoctorController(
        IDoctorModelFactory doctorModelFactory, 
        IMapper mapper, 
        IDoctorService doctorService)
    {
        _doctorModelFactory = doctorModelFactory;
        _mapper = mapper;
        _doctorService = doctorService;
    }

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }
    
    public async Task<IActionResult> List()
    {
        var model = await _doctorModelFactory.PrepareDoctorModelListAsync(new DoctorSearchModel());
        return View(model);
    }

    public async Task<IActionResult> Create()
    {
        var model = await _doctorModelFactory.PrepareDoctorModelAsync(new DoctorModel(), null);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DoctorModel model)
    {
        if (ModelState.IsValid)
        {
            var doctor = _mapper.Map<Doctor>(model);
            doctor.NormalizedUserName = doctor.UserName.ToUpper();

            await _doctorService.AddAsync(doctor);
            return RedirectToAction("List");
        }

        return RedirectToAction("Create");
    }
}