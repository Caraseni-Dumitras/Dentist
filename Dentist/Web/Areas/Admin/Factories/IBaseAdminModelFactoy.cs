using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.Admin.Factories;

public interface IBaseAdminModelFactoy
{
    Task PrepareAvailableProceduresAsync(IList<SelectListItem> items);
}