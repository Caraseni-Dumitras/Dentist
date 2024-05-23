using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Authorize(Policy = "ClientPolicy")]
public class BaseController: Controller
{
    
}