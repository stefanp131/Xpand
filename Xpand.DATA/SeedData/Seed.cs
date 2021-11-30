using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Xpand.DATA.DataContext;
using Xpand.DATA.Entities;

namespace Xpand.DATA.SeedData
{
    public class Seed
    {
        public static async Task SeedUsersAndPlanets(XpandContext context, UserManager<AppUser> userManager)
        {
            if (!(await context.Users.AnyAsync())) 
            {
                var userData = await System.IO.File.ReadAllTextAsync("Data/users.json");
                var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
                
                foreach (var user in users)
                {
                    user.UserName = user.UserName.ToLower();
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!(await context.Planets.AnyAsync())) 
            {
                var planetData = await System.IO.File.ReadAllTextAsync("Data/planets.json");
                var planets = JsonSerializer.Deserialize<List<Planet>>(planetData);
                                
                foreach (var planet in planets)
                {
                    await context.Planets.AddAsync(planet);
                }

                await context.SaveChangesAsync();
            }

        }
    }
}