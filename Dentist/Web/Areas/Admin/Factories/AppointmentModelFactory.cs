using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Web.Areas.Admin.Extensions;
using Web.Areas.Admin.Models.AppointmentModels;

namespace Web.Areas.Admin.Factories;

public class AppointmentModelFactory : IAppointmentModelFactory
{
    private readonly IAppointmentService _appointmentService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IProcedureService _procedureService;
    private readonly IDoctorService _doctorService;

    public AppointmentModelFactory(
        IAppointmentService appointmentService, 
        UserManager<ApplicationUser> userManager, 
        IProcedureService procedureService, 
        IDoctorService doctorService)
    {
        _appointmentService = appointmentService;
        _userManager = userManager;
        _procedureService = procedureService;
        _doctorService = doctorService;
    }

    public async Task<AppointmentSearchModel> PrepareAppointmentSearchModelAsync(AppointmentSearchModel searchModel)
    {
        if (searchModel == null)
            throw new ArgumentNullException(nameof(searchModel));

        searchModel.SetGridPageSize(10);

        return searchModel;
    }

    public async Task<AppointmentListModel> PrepareAppointmentListModelAsync(AppointmentSearchModel searchModel)
    {
        if (searchModel == null)
            throw new ArgumentNullException(nameof(searchModel));

        var appointments = await _appointmentService.SearchAppointmentsAsync(
            searchModel.Page - 1,
            searchModel.PageSize,
            searchModel.SearchByProcedureName);
        
        var appointmentModels = new List<AppointmentModel>();
        
        foreach (var appointment in appointments)
        {
            var user = await _userManager.FindByIdAsync(appointment.UserId);
            var procedure = await _procedureService.GetProcedureByIdAsync(appointment.ProcedureId);
            var doctor = await _doctorService.GetDoctorByIdAsync(appointment.DoctorId);
            
            var appointmentModel = new AppointmentModel
            {
                UserName = user?.FistName + " " + user?.LastName,
                UserEmail = user?.Email,
                ProcedureName = procedure.Name,
                CabinetNumber = procedure.CabinetNumber,
                DoctorName = doctor.FirstName + " " + doctor.LastName,
                DoctorEmail = doctor.Email,
                DateTime = appointment.Date.ToString("yyyy-MM-dd HH:mm:ss")
            };
            appointmentModels.Add(appointmentModel);
        }

        var model = await new AppointmentListModel().PrepareToGridAsync(searchModel, appointments, () => appointmentModels);

        return model;
    }
}