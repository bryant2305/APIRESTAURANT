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
    public static class DefaultWaiterUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser mesero = new();

            mesero.UserName = "Waiter";
            mesero.Email = "Waiter@mail.com";
            mesero.FirstName = "John";
            mesero.LastName = "Jon";
            mesero.EmailConfirmed = true;
            mesero.PhoneNumberConfirmed = true;
            mesero.TwoFactorEnabled = false;

            if (userManager.Users.All(u => u.Id != mesero.Id))
            {
                var topMesero = await userManager.FindByEmailAsync(mesero.Email);
                if (topMesero == null)
                {
                    await userManager.CreateAsync(mesero, "123Pa$$word");
                    await userManager.AddToRoleAsync(mesero, Roles.Waiter.ToString());
                }
            }
        }
    }
}
