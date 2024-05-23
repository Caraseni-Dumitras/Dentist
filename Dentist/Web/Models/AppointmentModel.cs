using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models;

public class AppointmentModel : BaseModel
{
    public AppointmentModel()
    {
        Procedures = new List<SelectListItem>();
        Doctors = new List<SelectListItem>();
    }
    
    public int SelectedProcedureId { get; set; }
    public IList<SelectListItem> Procedures { get; set; }

    public int SelectedDoctorId { get; set; }
    public IList<SelectListItem> Doctors { get; set; }

    public DateTime SelectedDate { get; set; } = DateTime.UtcNow;
    public string SelectedTime{ get; set; }
}