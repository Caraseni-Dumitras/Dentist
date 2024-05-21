using Application.Services;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.Models.ProcedureModels;

namespace Web.Areas.Admin.Controllers;

public class ProcedureController : AdminBaseController
{
    private readonly IMapper _mapper;
    private readonly IProcedureModelFactory _procedureModelFactory;
    private readonly IProcedureService _procedureService;

    public ProcedureController(
        IProcedureModelFactory procedureModelFactory, 
        IProcedureService procedureService, 
        IMapper mapper)
    {
        _procedureModelFactory = procedureModelFactory;
        _procedureService = procedureService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }
    
    public async Task<IActionResult> List()
    {
        var model = await _procedureModelFactory.PrepareProcedureModelListAsync(new ProcedureSearchModel());
        return View(model);
    }
    
    public async Task<IActionResult> Create()
    {
        var model = await _procedureModelFactory.PrepareProcedureModelAsync(new ProcedureModel(), null);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProcedureModel model)
    {
        if (ModelState.IsValid)
        {
            var procedure = _mapper.Map<Procedure>(model);

            await _procedureService.AddAsync(procedure);
            return RedirectToAction("List");
        }

        return RedirectToAction("Create");
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var procedure = await _procedureService.GetProcedureByIdAsync(id);

        if (procedure is null)
        {
            throw new ArgumentNullException(nameof(procedure));
        }
        
        var model = await _procedureModelFactory.PrepareProcedureModelAsync(new ProcedureModel(), procedure);
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(ProcedureModel model)
    {
        if (ModelState.IsValid)
        {
            var procedure = _mapper.Map<Procedure>(model);

            await _procedureService.UpdateAsync(procedure);
            return RedirectToAction("List");
        }

        return RedirectToAction("Edit", new{id = model.Id});
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var procedure = await _procedureService.GetProcedureByIdAsync(id);

        if (procedure is null)
        {
            throw new ArgumentNullException(nameof(procedure));
        }

        await _procedureService.DeleteAsync(procedure);
        
        return RedirectToAction("List");
    }
}