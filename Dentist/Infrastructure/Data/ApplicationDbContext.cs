using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Procedure> Procedures { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorProcedure> DoctorProcedures { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Doctor>()
            .HasKey(d => d.Id);

        modelBuilder.Entity<Procedure>()
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<DoctorProcedure>()
            .HasKey(dp => new { dp.DoctorId, dp.ProcedureId });

        modelBuilder.Entity<DoctorProcedure>()
            .HasOne(dp => dp.Doctor)
            .WithMany(d => d.DoctorProcedures)
            .HasForeignKey(dp => dp.DoctorId);

        modelBuilder.Entity<DoctorProcedure>()
            .HasOne(dp => dp.Procedure)
            .WithMany(p => p.DoctorProcedures)
            .HasForeignKey(dp => dp.ProcedureId);
    }
}