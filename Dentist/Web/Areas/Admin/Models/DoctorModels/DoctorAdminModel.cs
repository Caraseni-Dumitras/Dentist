using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.Admin.Models.DoctorModels;

public class DoctorAdminModel : BaseAdminModel
{
    public DoctorAdminModel()
    {
        SelectedProceduresIds = new List<int>();
        AvailableProcedures = new List<SelectListItem>();
    }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    
    public IList<int> SelectedProceduresIds { get; set; }
    public IList<SelectListItem> AvailableProcedures { get; set; }
}