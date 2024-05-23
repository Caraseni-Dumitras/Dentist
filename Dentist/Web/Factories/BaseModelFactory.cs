using Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using Web.Models;

namespace Web.Factories;

public class BaseModelFactory : IBaseModelFactory
{
    private readonly IProcedureService _procedureService;
    private readonly IDoctorService _doctorService;

    public BaseModelFactory(
        IProcedureService procedureService, 
        IDoctorService doctorService)
    {
        _procedureService = procedureService;
        _doctorService = doctorService;
    }

    public async Task PrepareAvailableProceduresAndDoctorsAsync(AppointmentModel model)
    {
        model.Doctors.AddRange(new List<SelectListItem>{new (){Text = "Select a Doctor", Value = "0"}});
        model.Procedures.AddRange(await GetProcedureListAsync());
    }

    public async Task<List<SelectListItem>> PrepareAvailableDoctorsAsync(int procedureId, DateTime appointmentDateTimeUtc)
    {
        var availableDoctors = await _doctorService.GetAllDoctorsByProcedureId(procedureId, appointmentDateTimeUtc);

        var doctorItems = availableDoctors.Select(d => new SelectListItem
        {
            Value = d.Id.ToString(),
            Text = d.FirstName + " " + d.LastName
        }).ToList();

        return doctorItems;
    }
    

    protected virtual async Task<List<SelectListItem>> GetProcedureListAsync()
    {
        var procedures = await _procedureService.GetAllProcedures();
        var selectedItems = procedures.Select(procedure => new SelectListItem { Text = procedure.Name, Value = procedure.Id.ToString() }).ToList();
        selectedItems.Insert(0, new SelectListItem { Text = "Select a Procedure", Value = "0" });
        
        return selectedItems;    }
}