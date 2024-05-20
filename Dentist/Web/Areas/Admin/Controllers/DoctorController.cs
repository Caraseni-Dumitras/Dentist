using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.Models.DoctorModels;

namespace Web.Areas.Admin.Controllers;

public class DoctorController : AdminBaseController
{
    private readonly IDoctorModelFactory _doctorModelFactory;

    public DoctorController(
        IDoctorModelFactory doctorModelFactory)
    {
        _doctorModelFactory = doctorModelFactory;
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
}