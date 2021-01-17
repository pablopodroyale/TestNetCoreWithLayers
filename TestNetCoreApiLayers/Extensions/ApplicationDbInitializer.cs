using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNetCore.Core.Model;

namespace TestNetCore.Api.Extensions
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.FindByNameAsync("ADMIN").Result == null)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = "ADMIN"
                };

                IdentityResult result = roleManager.CreateAsync(identityRole).Result;
            }

            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    User = new User() 
                    {
                        Email = "admin@admin.com",
                    }
                };

                IdentityResult result = userManager.CreateAsync(user, "P@ssword1234").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
