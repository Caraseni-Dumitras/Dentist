using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.Admin.Factories;

public interface IBaseAdminModelFactory
{
    Task PrepareAvailableProceduresAsync(IList<SelectListItem> items);
}