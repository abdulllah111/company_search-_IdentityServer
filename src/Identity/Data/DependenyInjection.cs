using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
{
     public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration){
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<AuthDbContext>(options =>{
                options.UseSqlite(connectionString);
            });
            services.AddIdentity<AppUser, IdentityRole>(config => {
                config.Password.RequiredLength = 8;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;


            })
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();
            
            
            return services;
        }
    }
}