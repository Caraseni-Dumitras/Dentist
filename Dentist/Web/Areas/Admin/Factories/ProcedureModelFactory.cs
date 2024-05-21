using Application.Services;
using AutoMapper;
using Core.Entities;
using Web.Areas.Admin.Extensions;
using Web.Areas.Admin.Models.ProcedureModels;

namespace Web.Areas.Admin.Factories;

public class ProcedureModelFactory : IProcedureModelFactory
{
    private readonly IMapper _mapper;
    private readonly IProcedureService _procedureService;

    public ProcedureModelFactory(
        IMapper mapper, 
        IProcedureService procedureService)
    {
        _mapper = mapper;
        _procedureService = procedureService;
    }

    public async Task<ProcedureModel> PrepareProcedureModelAsync(ProcedureModel model, Procedure doctor)
    {
        if (model is null)
        {
            model = new ProcedureModel();
        }
        
        if (doctor is not null)
        {
            model = _mapper.Map<ProcedureModel>(doctor);
        }

        return model;
    }

    public async Task<ProcedureListModel> PrepareProcedureModelListAsync(ProcedureSearchModel searchModel)
    {
        if (searchModel == null)
            throw new ArgumentNullException(nameof(searchModel));

        var procedures = await _procedureService.GetAllProcedures();

        var model = await new ProcedureListModel().PrepareToGridAsync(searchModel, procedures, () =>
        {
            return procedures.Select(procedure =>
            {
                var procedureModel = _mapper.Map<ProcedureModel>(procedure);
                return procedureModel;
            });
        });

        return model;
    }
}