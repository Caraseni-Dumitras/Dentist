namespace Web.Areas.Admin.Models.DoctorModels;

public class DoctorModel : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}