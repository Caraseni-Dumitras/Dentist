using Core;
using Web.Areas.Admin.Models;


namespace Web.Areas.Admin.Extensions;

public static class ModelExtensions
{
    public static async Task<TListModel> PrepareToGridAsync<TListModel, TModel, TObject>(this TListModel listModel,
        BaseAdminSearchModel adminSearchModel, IPagedList<TObject> objectList, Func<IEnumerable<TModel>> dataFillFunction)
        where TListModel : PagedListAdminModel<TModel>
        where TModel : BaseAdminModel
    {
        if (listModel == null)
            throw new ArgumentNullException(nameof(listModel));

        listModel.Data = dataFillFunction.Invoke().ToList();
        listModel.Draw = adminSearchModel?.Draw;
        listModel.RecordsTotal = objectList?.TotalCount ?? 0;
        listModel.RecordsFiltered = objectList?.TotalCount ?? 0;

        return listModel;
    }
}