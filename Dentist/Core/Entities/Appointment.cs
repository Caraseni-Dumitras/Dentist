namespace Core.Entities;

public class Appointment : BaseEntity
{
    public DateTime Date { get; set; }
    
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    
    public int ProcedureId { get; set; }
    public Procedure Procedure { get; set; }
}