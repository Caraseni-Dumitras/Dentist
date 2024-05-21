using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class UserRoleService : IUserRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRoleService(
        RoleManager<IdentityRole> roleManager, 
        UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    
    public async Task InsertApplicationRolesAsync()
    {
        string[] roleNames = ["Admin", "Client"];

        foreach (var roleName in roleNames)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}