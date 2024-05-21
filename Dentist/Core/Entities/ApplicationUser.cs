using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class ApplicationUser: IdentityUser
{
    public IList<Appointment> Appointments { get; set; }
 }