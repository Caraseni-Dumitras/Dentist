﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Policy = "AdminPolicy")]
public class AdminBaseController : Controller
{
    
}