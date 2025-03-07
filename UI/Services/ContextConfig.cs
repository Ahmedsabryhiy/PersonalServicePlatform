using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;

namespace UI.Services
{
    public class ContextConfig
    {
        private static readonly string seedAdminEmail = "admin@gmail.com";
        public static  async  Task SeedDataAsync(PersonServicePlatformContext context
            ,UserManager <ApplicationUser> userManager ,RoleManager<IdentityRole> roleMannager)
        {
            await SeedDataAsync(userManager , roleMannager);
        }

        private static async Task SeedDataAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMannager)
        {
            if (!await roleMannager.RoleExistsAsync("Admin"))
            {
                await  roleMannager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleMannager.RoleExistsAsync("User"))
            {
                await roleMannager.CreateAsync(new IdentityRole("User"));
            }
            if (!await roleMannager.RoleExistsAsync ("Provider"))
            {
                await roleMannager.CreateAsync(new IdentityRole("Provider"));
            }
            // 
            var adminEmail =seedAdminEmail ;
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var id = Guid.NewGuid().ToString();
                adminUser = new ApplicationUser()
                {
                    Id = id,
                    Email = adminEmail,
                    UserName = adminEmail
                };
                await userManager.CreateAsync(adminUser, "Admin@123");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
