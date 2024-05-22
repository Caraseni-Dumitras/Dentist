namespace Core.Entities;

public class Procedure : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CabinetNumber { get; set; }
    
    public IList<DoctorProcedure> DoctorProcedures { get; set; }
    public IList<Appointment> Appointments { get; set; }
}