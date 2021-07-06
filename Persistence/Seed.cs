using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {

            if (!context.AppRoles.Any())
            {
                var appRoles = new List<AppRole>
                {
                    new AppRole { Name = "Admin", NormalizedName = "ADMIN"},
                    new AppRole { Name = "Creator" , NormalizedName = "CREATOR"}

                };
                context.AppRoles.AddRange(appRoles);
                await context.SaveChangesAsync();
            }
            if (!context.AppUsers.Any())
            {


                var appuser = new List<AppUser>{
                    new AppUser {FirstName = "Bob", LastName = "Smith", UserName= "Bob Smith", Email = "bob.smith@test.com", EmailConfirmed = true},
                    new AppUser {FirstName = "Tom", LastName = "Smith", UserName= "Tom Smith", Email = "tom.smith@test.com", EmailConfirmed = true},
                    new AppUser {FirstName = "Jane", LastName = "Smith", UserName= "Jane Smith", Email = "jane.smith@test.com", EmailConfirmed = false},
                    new AppUser {FirstName = "Sam", LastName = "Smith", UserName= "Sam Smith", Email = "sam.smith@test.com", EmailConfirmed = false},
                };
                var role = context.AppRoles.FirstOrDefault(x => x.Name == "Creator");
                foreach (var user in appuser)
                {
                    context.AppUsers.Add(user);
                    await userManager.AddPasswordAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, "Creator");

                }

                var adminUser = new AppUser { FirstName = "Super", LastName = "Admin", UserName = "Super Admin", Email = "admin@test.com", EmailConfirmed = true };
                context.AppUsers.Add(adminUser);
                await userManager.AddPasswordAsync(adminUser, "Pa$$w0rd");
                await userManager.AddToRoleAsync(adminUser, "Admin");

                await context.SaveChangesAsync();


            }


        }
    }
}