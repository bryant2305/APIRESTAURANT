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
            ApplicationUser mesero = new();

            mesero.UserName = "SuperAdmin";
            mesero.Email = "SuperAdmin@mail.com";
            mesero.FirstName = "ELpapa";
            mesero.LastName = "UPA";
            mesero.EmailConfirmed = true;
            mesero.PhoneNumberConfirmed = true;
            mesero.TwoFactorEnabled = false;

            if (userManager.Users.All(u => u.Id != mesero.Id))
            {
                var topMesero = await userManager.FindByEmailAsync(mesero.Email);
                if (topMesero == null)
                {
                    await userManager.CreateAsync(mesero, "123Pass456P/word");
                    await userManager.AddToRoleAsync(mesero, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(mesero, Roles.Waiter.ToString());
                }
            }
        }
    }
}

