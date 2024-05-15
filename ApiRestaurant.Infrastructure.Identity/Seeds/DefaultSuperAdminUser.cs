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
    public static class DefaultSuperAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser superAdmin = new();

            superAdmin.UserName = "SuperAdmin";
            superAdmin.Email = "SuperAdmin@mail.com";
            superAdmin.FirstName = "ELpapa";
            superAdmin.LastName = "UPA";
            superAdmin.EmailConfirmed = true;
            superAdmin.PhoneNumberConfirmed = true;
            superAdmin.TwoFactorEnabled = false;

            if (userManager.Users.All(u => u.Id != superAdmin.Id))
            {
                var topMesero = await userManager.FindByEmailAsync(superAdmin.Email);
                if (topMesero == null)
                {
                    await userManager.CreateAsync(superAdmin, "123Pa$$word");
                    await userManager.AddToRoleAsync(superAdmin, Roles.SuperAdmin.ToString());
                    await userManager.AddToRoleAsync(superAdmin, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(superAdmin, Roles.Waiter.ToString());
                }
            }
        }
    }
}

