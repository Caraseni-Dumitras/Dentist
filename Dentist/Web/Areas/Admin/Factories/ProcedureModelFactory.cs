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

    public async Task<ProcedureAdminModel> PrepareProcedureModelAsync(ProcedureAdminModel adminModel, Procedure doctor)
    {
        if (adminModel is null)
        {
            adminModel = new ProcedureAdminModel();
        }
        
        if (doctor is not null)
        {
            adminModel = _mapper.Map<ProcedureAdminModel>(doctor);
        }

        return adminModel;
    }

    public async Task<ProcedureListAdminModel> PrepareProcedureModelListAsync(ProcedureAdminSearchModel adminSearchModel)
    {
        if (adminSearchModel == null)
            throw new ArgumentNullException(nameof(adminSearchModel));

        var procedures = await _procedureService.GetAllProcedures();

        var model = await new ProcedureListAdminModel().PrepareToGridAsync(adminSearchModel, procedures, () =>
        {
            return procedures.Select(procedure =>
            {
                var procedureModel = _mapper.Map<ProcedureAdminModel>(procedure);
                return procedureModel;
            });
        });

        return model;
    }
}