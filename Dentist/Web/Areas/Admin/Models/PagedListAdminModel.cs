namespace Web.Areas.Admin.Models;

public abstract class PagedListAdminModel<T> : BaseAdminModel, IPagedModel<T> where T : BaseAdminModel
{
    public IEnumerable<T> Data { get; set; }
    public string Draw { get; set; }
    public int RecordsFiltered { get; set; }
    public int RecordsTotal { get; set; }
}