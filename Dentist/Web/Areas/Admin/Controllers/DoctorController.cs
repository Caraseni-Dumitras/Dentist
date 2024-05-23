using Application.Services;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.Models.DoctorModels;

namespace Web.Areas.Admin.Controllers;

public class DoctorController : AdminBaseController
{
    private readonly IDoctorModelFactory _doctorModelFactory;
    private readonly IMapper _mapper;
    private readonly IDoctorService _doctorService;
    private readonly IDoctorProcedureService _doctorProcedureService;

    public DoctorController(
        IDoctorModelFactory doctorModelFactory, 
        IMapper mapper, 
        IDoctorService doctorService,
        IDoctorProcedureService doctorProcedureService)
    {
        _doctorModelFactory = doctorModelFactory;
        _mapper = mapper;
        _doctorService = doctorService;
        _doctorProcedureService = doctorProcedureService;
    }

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }
    
    public async Task<IActionResult> List()
    {
        var model = await _doctorModelFactory.PrepareDoctorModelListAsync(new DoctorAdminSearchModel());
        return View(model);
    }

    public async Task<IActionResult> Create()
    {
        var model = await _doctorModelFactory.PrepareDoctorModelAsync(new DoctorAdminModel(), null);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(DoctorAdminModel adminModel)
    {
        if (ModelState.IsValid)
        {
            var doctor = _mapper.Map<Doctor>(adminModel);

            await _doctorService.AddAsync(doctor);
            
            foreach (var selectedProceduresId in adminModel.SelectedProceduresIds)
            {
                await _doctorProcedureService.AddAsync(new DoctorProcedure()
                {
                    ProcedureId = selectedProceduresId,
                    DoctorId = doctor.Id
                });
            }
            
            return RedirectToAction("List");
        }

        adminModel = await _doctorModelFactory.PrepareDoctorModelAsync(adminModel, null);
        return View(adminModel);
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var doctor = await _doctorService.GetDoctorByIdAsync(id);

        if (doctor is null)
        {
            throw new ArgumentNullException(nameof(doctor));
        }
        
        var model = await _doctorModelFactory.PrepareDoctorModelAsync(new DoctorAdminModel(), doctor);
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(DoctorAdminModel adminModel)
    {
        if (ModelState.IsValid)
        {
            var doctor = _mapper.Map<Doctor>(adminModel);
            
            await _doctorService.UpdateAsync(doctor);

            var doctorProcedures = await _doctorProcedureService.GetAllDoctorProceduresByDoctorIdAsync(doctor.Id);
            
            foreach (var doctorProcedure in doctorProcedures.Where(doctorProcedure => !adminModel.SelectedProceduresIds.Any(mp => mp == doctorProcedure.Id)))
            {
                await _doctorProcedureService.DeleteAsync(doctorProcedure);
            }
            
            foreach (var procedureId in adminModel.SelectedProceduresIds)
            {
                if (await _doctorProcedureService.GetDoctorProcedureByDoctorAndProcedureIdAsync(doctor.Id ,procedureId) == null)
                {
                    await _doctorProcedureService.AddAsync(new DoctorProcedure()
                    {
                        DoctorId = doctor.Id,
                        ProcedureId = procedureId
                    });
                }
            }
            
            return RedirectToAction("List");
        }

        adminModel = await _doctorModelFactory.PrepareDoctorModelAsync(adminModel, null);
        return View(adminModel);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var doctor = await _doctorService.GetDoctorByIdAsync(id);

        if (doctor is null)
        {
            throw new ArgumentNullException(nameof(doctor));
        }

        await _doctorService.DeleteAsync(doctor);
        
        return RedirectToAction("List");
    }
}