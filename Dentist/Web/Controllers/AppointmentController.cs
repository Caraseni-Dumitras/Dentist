using System.Globalization;
using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Factories;
using Web.Models;

namespace Web.Controllers;

public class AppointmentController : BaseController
{
    private readonly IBaseModelFactory _baseModelFactory;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(
        IBaseModelFactory baseModelFactory, 
        UserManager<ApplicationUser> userManager, IAppointmentService appointmentService)
    {
        _baseModelFactory = baseModelFactory;
        _userManager = userManager;
        _appointmentService = appointmentService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Create()
    {
        var model = new AppointmentModel();

        if (model.SelectedDate.Hour > 16)
        {
            model.SelectedDate = model.SelectedDate.AddDays(1);
        }
        
        await _baseModelFactory.PrepareAvailableProceduresAndDoctorsAsync(model);

        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(AppointmentModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                await _baseModelFactory.PrepareAvailableProceduresAndDoctorsAsync(model);
                return View(model);
            }
            
            var selectedDateTime = DateTime.ParseExact(
                $"{model.SelectedDate:yyyy-MM-dd} {model.SelectedTime}", 
                "yyyy-MM-dd HH:mm", 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None
            ).ToUniversalTime();
            
            var appointment = new Appointment
            {
                UserId = user.Id,
                DoctorId = model.SelectedDoctorId,
                ProcedureId = model.SelectedProcedureId,
                Date = selectedDateTime
            };
            
            await _appointmentService.AddAsync(appointment);

            return RedirectToAction("Confirmation");
        }

        await _baseModelFactory.PrepareAvailableProceduresAndDoctorsAsync(model);

        return View(model);
    }
    
    [HttpGet]
    public async Task<JsonResult> GetDoctors(int procedureId, DateTime appointmentDateTimeUtc)
    {
        
        
        var doctors = await _baseModelFactory.PrepareAvailableDoctorsAsync(procedureId, appointmentDateTimeUtc);

        return new JsonResult(doctors);
    }
    
    public IActionResult Confirmation()
    {
        return View();
    }
}