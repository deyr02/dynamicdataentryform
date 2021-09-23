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

            //User Roles
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

            //User
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


            //Control Types
            if (!context.ControlTypes.Any())
            {
                var controlTypes = new List<ControlType>
                {
                    new ControlType{Name = "TextBox"},
                    new ControlType{Name = "TextArea"},
                    new ControlType{Name = "Date Picker"},
                    new ControlType{Name = "Date and Time picker"},
                    new ControlType{Name = "RadioButtonGroup"},
                    new ControlType{Name = "CheckBox"},
                    new ControlType{Name = "CheckBoxGroup"},
                    new ControlType{Name = "DropdownList"},
                };

                foreach (var control in controlTypes)
                {
                    context.ControlTypes.Add(control);
                }
                await context.SaveChangesAsync();
            }


            //DataTypes
            if (!context.DataTypes.Any())
            {
                var dataTypes = new List<DataType>
                {
                    new DataType{Name = "string"},
                    new DataType{Name = "Date"},
                    new DataType{Name = "PhoneNumber"},
                    new DataType{Name = "email"},
                    new DataType{Name = "Integer"},
                    new DataType{Name = "double"},
                    new DataType{Name = "decimal"},
                    new DataType{Name = "bool"}


                };

                foreach (var dataType in dataTypes)
                {
                    context.DataTypes.Add(dataType);
                }
                await context.SaveChangesAsync();
            }

            //Rules
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

                foreach (var rule in rules)
                {
                    context.Rules.Add(rule);
                }
                await context.SaveChangesAsync();
            }

            //Forms
            if (!context.Forms.Any())
            {
                var user_1 = context.Users.FirstOrDefault(x => x.Email == "bob.smith@test.com");
                var user_2 = context.Users.FirstOrDefault(x => x.Email == "sam.smith@test.com");
                var forms = new List<Form>()
                {

                    new Form(){
                        FormName = "Sample Form One",
                        Description= "This is a sample form one",
                        Created = DateTime.Now,
                        UserID = user_1.Id
                    },
                    new Form(){
                        FormName = "Sample Form Two",
                        Description= "This is a sample form two",
                        Created = DateTime.Now,
                        UserID = user_1.Id
                    },

                };

                foreach (var form in forms)
                {
                    context.Forms.Add(form);
                }
                await context.SaveChangesAsync();
            }

            ///Attribute
            if (!context.Attributes.Any())
            {
                var form_1 = context.Forms.FirstOrDefault(x => x.FormName == "Sample Form One");
                var form_2 = context.Forms.FirstOrDefault(x => x.FormName == "Sample Form Two");

                var attributes = new List<Domain.Attribute>()
                {
                    new Domain.Attribute(){
                        AttributeId = 1,
                        AttributeName = "Frist Name",
                        Description = "Please Enter your First name",

                        FormId = form_1.Id,
                        DataTypeId = 1,
                        ControlTypeId = 1,
                    },
                    new Domain.Attribute(){
                        AttributeId = 2,
                        AttributeName = "Last Name",
                        Description = "Please Enter your Last name",

                        FormId = form_1.Id,
                        DataTypeId = 1,
                        ControlTypeId = 1,
                    },
                    new Domain.Attribute(){
                        AttributeId = 3,
                        AttributeName = "Address",
                        Description = "Please Enter your Address",

                        FormId = form_1.Id,
                        DataTypeId = 1,
                        ControlTypeId = 1,
                    },
                    new Domain.Attribute(){
                        AttributeId = 4,
                        AttributeName = "Email",
                        Description = "Please Enter your email address",

                        FormId = form_1.Id,
                        DataTypeId = 4,
                        ControlTypeId = 1,
                    },
                    new Domain.Attribute(){
                        AttributeId = 5,
                        AttributeName = "Phone Number",
                        Description = "Please Enter your Phone Number",

                        FormId = form_1.Id,
                        DataTypeId = 3,
                        ControlTypeId = 1,
                    },
                    new Domain.Attribute(){
                        AttributeId = 6,
                        AttributeName = "Gender",
                        Description = "Please select your gender",

                        FormId = form_1.Id,
                        DataTypeId = 1,
                        ControlTypeId = 5,
                    },
                    new Domain.Attribute(){
                        AttributeId = 7,
                        AttributeName = "Work type",
                        Description = "Please select work type",

                        FormId = form_1.Id,
                        DataTypeId = 1,
                        ControlTypeId = 8,
                    },
                    new Domain.Attribute(){
                        AttributeId = 8,
                        AttributeName = "Trams and condition",
                        Description = "Please accpet the terms and condition",

                        FormId = form_1.Id,
                        DataTypeId = 8,
                        ControlTypeId = 6,
                    },

                    //Sample form 2

                    new Domain.Attribute(){
                        AttributeId = 9,
                        AttributeName = "Frist Name",
                        Description = "Please Enter your First name",

                        FormId = form_2.Id,
                        DataTypeId = 1,
                        ControlTypeId = 1,
                    },
                    new Domain.Attribute(){
                        AttributeId = 10,
                        AttributeName = "Last Name",
                        Description = "Please Enter your Last name",

                        FormId = form_2.Id,
                        DataTypeId = 1,
                        ControlTypeId = 1,
                    },
                    new Domain.Attribute(){
                        AttributeId = 11,
                        AttributeName = "Address",
                        Description = "Please Enter your Address",

                        FormId = form_2.Id,
                        DataTypeId = 1,
                        ControlTypeId = 1,
                    },
                    new Domain.Attribute(){
                        AttributeId = 12,
                        AttributeName = "Email",
                        Description = "Please Enter your email address",

                        FormId = form_2.Id,
                        DataTypeId = 4,
                        ControlTypeId = 1,
                    },
                    new Domain.Attribute(){
                        AttributeId = 13,
                        AttributeName = "Phone Number",
                        Description = "Please Enter your Phone Number",

                        FormId = form_2.Id,
                        DataTypeId = 3,
                        ControlTypeId = 1,
                    },
                    new Domain.Attribute(){
                        AttributeId = 14,
                        AttributeName = "Gender",
                        Description = "Please select your gender",

                        FormId = form_2.Id,
                        DataTypeId = 1,
                        ControlTypeId = 5,
                    },
                    new Domain.Attribute(){
                        AttributeId = 15,
                        AttributeName = "Work type",
                        Description = "Please select work type",

                        FormId = form_2.Id,
                        DataTypeId = 1,
                        ControlTypeId = 8,
                    },
                    new Domain.Attribute(){
                        AttributeId = 16,
                        AttributeName = "Tech Stack",
                        Description = "Please select current set of skills",

                        FormId = form_2.Id,
                        DataTypeId = 8,
                        ControlTypeId = 7,
                    },
                };

                foreach (var att in attributes)
                {
                    context.Attributes.Add(att);
                }
                await context.SaveChangesAsync();
            }

            ///Attribute options
            if (!context.AttributeValueOptions.Any())
            {

                var options = new List<AttributeValueOption>()
                {
                    //form-1
                    // radio options
                    new AttributeValueOption(){
                        Id = 1,
                        AttributeId =6,
                        Option = "Male"
                    },
                    new AttributeValueOption(){
                        Id = 2,
                        AttributeId =6,
                        Option = "Female"
                    },
                    //form-1
                    // drop-downlist-options 
                    new AttributeValueOption(){
                        Id = 3,
                        AttributeId =7,
                        Option = "FullTime"
                    },
                    new AttributeValueOption(){
                        Id = 4,
                        AttributeId =7,
                        Option = "PartTime"
                    },
                    new AttributeValueOption(){
                        Id = 5,
                        AttributeId =7,
                        Option = "Casual"
                    },

                    //form-2
                    //radio-options
                    new AttributeValueOption(){
                        Id = 6,
                        AttributeId =14,
                        Option = "FullTime"
                    },
                    new AttributeValueOption(){
                        Id = 7,
                        AttributeId =14,
                        Option = "PartTime"
                    },
                    //form-2
                    //drop-downlist
                    new AttributeValueOption(){
                        Id = 8,
                        AttributeId =15,
                        Option = "FullTime"
                    },
                    new AttributeValueOption(){
                        Id = 9,
                        AttributeId =15,
                        Option = "PartTime"
                    },
                    new AttributeValueOption(){
                        Id = 10,
                        AttributeId =15,
                        Option = "Casual"
                    },
                
                    //form-2
                    //checkbox-groups
                    new AttributeValueOption(){
                        Id = 11,
                        AttributeId =16,
                        Option = "C#"
                    },
                    new AttributeValueOption(){
                        Id = 12,
                        AttributeId =16,
                        Option = "ASP.NET Core"
                    },
                    new AttributeValueOption(){
                        Id = 13,
                        AttributeId =16,
                        Option = "REST API"
                    },
                    new AttributeValueOption(){
                        Id = 14,
                        AttributeId =16,
                        Option = "SQL Sever"
                    },
                    new AttributeValueOption(){
                        Id = 15,
                        AttributeId =16,
                        Option = "PostGreSQL"
                    },
                    new AttributeValueOption(){
                        Id = 16,
                        AttributeId =16,
                        Option = "HTML5"
                    },
                    new AttributeValueOption(){
                        Id = 17,
                        AttributeId =16,
                        Option = "CSS3"
                    },
                    new AttributeValueOption(){
                        Id = 18,
                        AttributeId =16,
                        Option = "JavaScript"
                    },
                    new AttributeValueOption(){
                        Id = 19,
                        AttributeId =16,
                        Option = "React.js"
                    },
                    new AttributeValueOption(){
                        Id = 20,
                        AttributeId =16,
                        Option = "Angular.js"
                    }
                };

                foreach (var att_opt in options)
                {
                    context.AttributeValueOptions.Add(att_opt);
                }
                await context.SaveChangesAsync();

            }

            //Attribute Rule
            if(!context.AttributeRules.Any()){
                
            }


            /// Logs
            if (!context.Logs.Any())
            {
                var logs = new List<Log>(){
                    new Log (){
                        Id= 1,
                        CreatedAt = DateTime.Now
                    },
                    new Log (){
                        Id= 2,
                        CreatedAt = DateTime.Now
                    },
                    new Log (){
                        Id= 3,
                        CreatedAt = DateTime.Now
                    },
                    new Log (){
                        Id= 4,
                        CreatedAt = DateTime.Now
                    },
                    new Log (){
                        Id= 5,
                        CreatedAt = DateTime.Now
                    },
                    new Log (){
                        Id= 6,
                        CreatedAt = DateTime.Now
                    },
                };

                foreach (var log in logs)
                {
                    context.Logs.Add(log);
                }
                await context.SaveChangesAsync();
            }


            ///Attribute Logs 
            if (!context.AttributeLogs.Any())
            {
                //form: 1
                //Record: 1
                var logId = 1;
                var att_log = new List<AttributeLog>(){
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 1,
                        Value  = "Sam"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 2,
                        Value  = "Smith"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 3,
                        Value  = "6/4 Mount View Road, Sandringham, 1012, Auckland, New Zealand"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 4,
                        Value  = "sam_smith@email.com"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 5,
                        Value  = "+6402102960832"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 6,
                        Value  = "Male"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 7,
                        Value  = "FullTime"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 8,
                        Value  = "true"
                    },
                };

                foreach (var row in att_log)
                {
                    context.AttributeLogs.Add(row);
                }
                await context.SaveChangesAsync();


                //form: 1
                //Record: 2
                logId = 2;
                att_log = new List<AttributeLog>(){
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 1,
                        Value  = "Jane"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 2,
                        Value  = "Smith"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 3,
                        Value  = "6/4 Mount View Road, Sandringham, 1012, Auckland, New Zealand"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 4,
                        Value  = "Jane_smith@email.com"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 5,
                        Value  = "+6402102960832"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 6,
                        Value  = "Female"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 7,
                        Value  = "FullTime"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 8,
                        Value  = "true"
                    },
                };

                foreach (var row in att_log)
                {
                    context.AttributeLogs.Add(row);
                }
                await context.SaveChangesAsync();


                //form: 1
                //Record: 3
                logId = 3;
                att_log = new List<AttributeLog>(){
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 1,
                        Value  = "William"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 2,
                        Value  = "Smith"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 3,
                        Value  = "6/4 Mount View Road, Sandringham, 1012, Auckland, New Zealand"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 4,
                        Value  = "will_smith@email.com"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 5,
                        Value  = "+6402102960832"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 6,
                        Value  = "Male"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 7,
                        Value  = "FullTime"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 8,
                        Value  = "true"
                    },
                };

                foreach (var row in att_log)
                {
                    context.AttributeLogs.Add(row);
                }
                await context.SaveChangesAsync();


                //form: 2
                //Record: 1
                logId = 4;
                att_log = new List<AttributeLog>(){
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 9,
                        Value  = "Jacob"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 10,
                        Value  = "Anderson"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 11,
                        Value  = "6/4 Mount View Road, Sandringham, 1012, Auckland, New Zealand"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 12,
                        Value  = "jacob_anderson@email.com"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 13,
                        Value  = "+6402102960832"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 14,
                        Value  = "Male"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 15,
                        Value  = "FullTime"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 16,
                        Value  = "C#, ASP.NET Core, SQL Sever, React"
                    },
                };

                foreach (var row in att_log)
                {
                    context.AttributeLogs.Add(row);
                }
                await context.SaveChangesAsync();

                //form: 2
                //Record: 2
                logId = 5;
                att_log = new List<AttributeLog>(){
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 9,
                        Value  = "Miccheal"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 10,
                        Value  = "Jackson"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 11,
                        Value  = "6/4 Mount View Road, Sandringham, 1012, Auckland, New Zealand"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 12,
                        Value  = "michael_jackson@email.com"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 13,
                        Value  = "+6402102960832"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 14,
                        Value  = "Male"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 15,
                        Value  = "FullTime"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 16,
                        Value  = "C#, ASP.NET Core, SQL Sever, React, HTML5, CSS3, JavaScript"
                    },
                };

                foreach (var row in att_log)
                {
                    context.AttributeLogs.Add(row);
                }
                await context.SaveChangesAsync();

                //form: 2
                //Record: 3
                logId = 6;
                att_log = new List<AttributeLog>(){
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 9,
                        Value  = "Katty"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 10,
                        Value  = "Perry"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 11,
                        Value  = "6/4 Mount View Road, Sandringham, 1012, Auckland, New Zealand"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 12,
                        Value  = "katty_perry@email.com"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 13,
                        Value  = "+6402102960832"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 14,
                        Value  = "Male"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 15,
                        Value  = "FullTime"
                    },
                    new AttributeLog(){
                        LogId = logId,
                        AttributeId = 16,
                        Value  = " ASP.NET Core, React"
                    },
                };

                foreach (var row in att_log)
                {
                    context.AttributeLogs.Add(row);
                }
                await context.SaveChangesAsync();


            }


        }
    }
}