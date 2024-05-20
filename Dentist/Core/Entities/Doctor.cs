namespace Core.Entities;

public class Doctor : BaseEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string NormalizedUserName { get; set; }
    public string PhoneNumber { get; set; }
    public List<DoctorProcedure> DoctorProcedures { get; set; } = [];
}