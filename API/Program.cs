using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //stroing the buid command in a variable
            var host = CreateHostBuilder(args).Build();
            //create host service within this method
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                //geting serveice that are inject in startup class
                var context = services.GetRequiredService<DataContext>();

                //getting usermanager service
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                //Apply pending migration to the database and create the database
                await context.Database.MigrateAsync();
                //Seeding data into database.
                await Seed.SeedData(context, userManager);
            }
            catch (Exception ex)
            {
                //logging error
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            }
            //run the application
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
