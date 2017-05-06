using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventBookingSystem.Models
{
    public static class IdentitySeedData 
    {
        // usernames are Admin, 5382361 and 5382362
        // passwords are the some
        private const string adminUser = "5382361"; 
        private const string adminPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app) 
        {
            UserManager<IdentityUser> userManager = app.ApplicationServices 
                .GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            
            RoleManager<IdentityRole> roleManager = app.ApplicationServices 
                .GetRequiredService<RoleManager<IdentityRole>>();
            IdentityRole role = await roleManager.FindByNameAsync("Student");
            if(role==null)
            {
                role=new IdentityRole("Student");
                await roleManager.CreateAsync(role);
            }
            if (user == null) 
            {
                user = new IdentityUser(adminUser);
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user,"Student"); 
            }
        }
        
    }
}