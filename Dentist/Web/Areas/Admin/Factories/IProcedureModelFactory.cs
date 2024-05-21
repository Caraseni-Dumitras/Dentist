using Core.Entities;
using Web.Areas.Admin.Models.ProcedureModels;

namespace Web.Areas.Admin.Factories;

public interface IProcedureModelFactory
{
    Task<ProcedureModel> PrepareProcedureModelAsync(ProcedureModel model, Procedure doctor);
    Task<ProcedureListModel> PrepareProcedureModelListAsync(ProcedureSearchModel searchModel);
}