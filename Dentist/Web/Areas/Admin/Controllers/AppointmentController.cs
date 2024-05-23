using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.Models.AppointmentModels;

namespace Web.Areas.Admin.Controllers;

public class AppointmentController : AdminBaseController
{
    private readonly IAppointmentModelFactory _appointmentModelFactory;

    public AppointmentController(
        IAppointmentModelFactory appointmentModelFactory)
    {
        _appointmentModelFactory = appointmentModelFactory;
    }

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }
    
    public virtual async Task<IActionResult> List()
    {
        var model = await _appointmentModelFactory.PrepareAppointmentSearchModelAsync(new AppointmentSearchModel());

        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> List(AppointmentSearchModel searchModel)
    {
        var appointments = await _appointmentModelFactory.PrepareAppointmentListModelAsync(searchModel);
        return Json(appointments);
    }
}