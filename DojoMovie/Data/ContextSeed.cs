using DojoMovie.Models;
using Microsoft.AspNetCore.Identity;

namespace DojoMovie.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Premium.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basic.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Free.ToString()));
        }
    }
}
