namespace Web.Areas.Admin.Models;

public abstract class PagedListModel<T> : BaseModel, IPagedModel<T> where T : BaseModel
{
    public IEnumerable<T> Data { get; set; }
    public string Draw { get; set; }
    public int RecordsFiltered { get; set; }
    public int RecordsTotal { get; set; }
}