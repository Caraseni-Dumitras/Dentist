using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Procedure> Procedures { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<DoctorProcedure> DoctorProcedures { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DoctorProcedure>()
            .HasKey(dp => new {dp.Id, dp.DoctorId, dp.ProcedureId });

        modelBuilder.Entity<DoctorProcedure>()
            .HasOne(dp => dp.Doctor)
            .WithMany(d => d.DoctorProcedures)
            .HasForeignKey(dp => dp.DoctorId);

        modelBuilder.Entity<DoctorProcedure>()
            .HasOne(dp => dp.Procedure)
            .WithMany(p => p.DoctorProcedures)
            .HasForeignKey(dp => dp.ProcedureId);
        
        modelBuilder.Entity<DoctorProcedure>()
            .Property(dp => dp.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.User)
            .WithMany(u => u.Appointments)
            .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Procedure)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.ProcedureId);
        
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId);
    }
}