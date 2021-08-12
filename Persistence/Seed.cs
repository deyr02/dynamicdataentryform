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




            if (!context.ControlTypes.Any())
            {
                var controlTypes = new List<ControlType>
                {
                    new ControlType{Name = "TextBox"},
                    new ControlType{Name = "TextArea"},
                    new ControlType{Name = "Date Picker"},
                    new ControlType{Name = "Date and Time picker"},
                    new ControlType{Name = "RadioButtons"},
                    new ControlType{Name = "CheckBoxs"},
                    new ControlType{Name = "DropdownList"},
                };

                foreach (var control in controlTypes)
                {
                    context.ControlTypes.Add(control);
                }
                await context.SaveChangesAsync();
            }




            if (!context.DataTypes.Any())
            {
                var dataTypes = new List<DataType>
                {
                    new DataType{Name = "string"},
                    new DataType{Name = "Date"},
                    new DataType{Name = "email"},
                    new DataType{Name = "Integer"},
                    new DataType{Name = "double"},
                    new DataType{Name = "decimal"}

                };

                foreach (var dataType in dataTypes)
                {
                    context.DataTypes.Add(dataType);
                }
                await context.SaveChangesAsync();
            }

            if ((!context.Rules.Any()))
            {
                var rules = new List<Rule>()
                {
                    new Rule{Name= "nullable" },
                    new Rule{Name= "max"},
                    new Rule{Name= "min"},
                    new Rule{Name= "Regex"},
                    new Rule{Name= "File Format"},

                };

                foreach(var rule in rules){
                    context.Rules.Add(rule);
                }
                await context.SaveChangesAsync();
            }


        }
    }
}