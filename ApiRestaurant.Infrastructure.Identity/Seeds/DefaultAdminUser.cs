using ApiRestaurant.Core.Application.Enums;
using ApiRestaurant.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Infrastructure.Identity.Seeds
{
    public static class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser admin = new();
            
            admin.UserName = "Admin";
            admin.Email = "Admin@mail.com";
            admin.FirstName = "Pedrito";
            admin.LastName = "G";
            admin.EmailConfirmed = true;
            admin.PhoneNumberConfirmed = true;
            admin.TwoFactorEnabled = false;

            if (userManager.Users.All(u => u.Id != admin.Id))
            {
                var topMesero = await userManager.FindByEmailAsync(admin.Email);
                if (topMesero == null)
                {
                    await userManager.CreateAsync(admin, "123Pass456P/word");
                    await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
                }
            }
        }
    }
}
