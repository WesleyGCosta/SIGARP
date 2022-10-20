using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Configuration
{
    public static class StartUserConfig
    {
        private static void StartProfile(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var profile = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.CreateAsync(profile).Wait();
            }
        }

        private static void StartUser(UserManager<User> userManager)
        {
            if(userManager.FindByNameAsync("Admin@sigarp.com").Result == null)
            {
                var user = new User
                {
                    UserName = "Admin@gmail.com",
                    FirstName = "Adminstrador",
                    LastName = "Sistema",
                    Email = "Admin@sigarp.com",
                    PhoneNumber = "(99) 9 9999-9999"
                };
                var result = userManager.CreateAsync(user, "Admin@123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public static void StartIdentity(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            StartProfile(roleManager);
            StartUser(userManager);
        }
    }
}
