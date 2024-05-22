namespace Core.Entities;

public class Doctor : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public IList<DoctorProcedure> DoctorProcedures { get; set; } = new List<DoctorProcedure>();
    public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
}