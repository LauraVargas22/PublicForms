using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Infrastructure.Repositories;

namespace ApiProject.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()   //WithOrigins("https://dominio.com")
                    .AllowAnyMethod()          //WithMethods("GET","POST")
                    .AllowAnyHeader());        //WithHeaders("accept","content-type")
            });

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}