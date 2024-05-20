namespace Web.Areas.Admin.Models;

public interface IPagingRequestModel
{
    int Page { get; }
    int PageSize { get; }
}