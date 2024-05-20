namespace Core.Entities;

public class Procedure : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<DoctorProcedure> DoctorProcedures { get; set; } = [];
}