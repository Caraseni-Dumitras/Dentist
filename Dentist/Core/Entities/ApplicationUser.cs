using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class ApplicationUser: IdentityUser
{
    public string FistName { get; set; }
    public string LastName { get; set; }
    public IList<Appointment> Appointments { get; set; }
 }