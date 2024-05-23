namespace Web.Areas.Admin.Models.AppointmentModels;

public class AppointmentModel : BaseAdminModel
{
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string ProcedureName { get; set; }
    public string DoctorName { get; set; }
    public string DoctorEmail { get; set; }
    public string CabinetNumber { get; set; }
    public string DateTime { get; set; }
}