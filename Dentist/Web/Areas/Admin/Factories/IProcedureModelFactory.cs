using Core.Entities;
using Web.Areas.Admin.Models.ProcedureModels;

namespace Web.Areas.Admin.Factories;

public interface IProcedureModelFactory
{
    Task<ProcedureAdminModel> PrepareProcedureModelAsync(ProcedureAdminModel adminModel, Procedure doctor);
    Task<ProcedureListAdminModel> PrepareProcedureModelListAsync(ProcedureAdminSearchModel adminSearchModel);
}