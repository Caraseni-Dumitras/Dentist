namespace Core.Entities;

public class DoctorProcedure : BaseEntity
{
    public int DoctorId { get; set; }
    public int ProcedureId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public Procedure Procedure { get; set; } = null!;
}