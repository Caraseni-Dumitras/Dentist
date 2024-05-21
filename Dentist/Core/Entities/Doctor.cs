namespace Core.Entities;

public class Doctor : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public IList<Procedure> Procedures { get; set; }
    public IList<Appointment> Appointments { get; set; }
}