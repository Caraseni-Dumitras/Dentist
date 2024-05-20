
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers;

public class AdminHomeController : AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}