using Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.Admin.Factories;

public class BaseAdminModelFactory: IBaseAdminModelFactory
{
    private readonly IProcedureService _procedureService;

    public BaseAdminModelFactory(
        IProcedureService procedureService)
    {
        _procedureService = procedureService;
    }
    
    public async Task PrepareAvailableProceduresAsync(IList<SelectListItem> items)
    {
        if (items == null)
            throw new ArgumentNullException(nameof(items));
        
        var availableProcedureItems = await GetProcedureListAsync();
        foreach (var procedureItem in availableProcedureItems)
        {
            items.Add(procedureItem);
        }
    }

    protected virtual async Task<List<SelectListItem>> GetProcedureListAsync()
    {
        var procedures = await _procedureService.GetAllProcedures();

        return procedures.Select(procedure => new SelectListItem { Text = procedure.Name, Value = procedure.Id.ToString() }).ToList();
    }
}