using Application.Core;
using Application.Forms;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
                IConfiguration config)
        {

            services.AddSwaggerGen(c =>
                       {
                           c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                       });

            //adding dbcontext service
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            //add for react jest learning purpose
            services.AddCors(opt =>
                 {
                     opt.AddPolicy("CorsPolicy", policy =>
                     {
                         policy.AllowAnyMethod().AllowAnyHeader().WithOrigins(new string[] { "http://localhost:3000", "test" });
                     });
                 });

            //////
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            
            return services;
        }
    }
}