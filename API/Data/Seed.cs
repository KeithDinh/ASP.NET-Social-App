using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            // if db table/collection contains any data/document
            if(await userManager.Users.AnyAsync()) return;

            // read raw data from file
            var userData = await System.IO.File.ReadAllBytesAsync("Data/UserSeedData.json");
            // serialize them into JSON            
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if(users == null) return;

            var roles = new List<AppRole>
            {
                new AppRole{Name ="Member"}, // Name is inherited from IdentityRole Library
                new AppRole{Name ="Admin"},
                new AppRole{Name ="Moderator"},
            };

            foreach(var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach(var user in users)
            {
                // this is seeding, so set users' 1st photo to approved
                user.Photos.First().isApproved = true;
                // convert username of each user to lower case
                user.UserName = user.UserName.ToLower();
                // create new entry in the table/collection
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");
            }

            var admin = new AppUser{
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] {"Admin", "Moderator"});
        }
    }
}