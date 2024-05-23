namespace Web.Areas.Admin.Models;

public class BaseAdminSearchModel : BaseAdminModel, IPagingRequestModel
{
    protected BaseAdminSearchModel()
    {
        Length = 10;
    }

    public int Page => (Start / Length) + 1;
    public int PageSize => Length;

    public string AvailablePageSizes { get; set; }

    public string Draw { get; set; }

    public int Start { get; set; }

    public int Length { get; set; }

    public void SetGridPageSize(int pageSize)
    {
        Start = 0;
        Length = pageSize;
    }
}