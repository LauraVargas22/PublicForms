using Application.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using System.Text;
using System.Threading.RateLimiting;
using System.Threading.Tasks;
using ApiProject.Helpers;
using ApiProject.Helpers.Errors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using AutoMapper.Execution;
using Domain.Entities;

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
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPasswordHasher<UserMember>, PasswordHasher<UserMember>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        public static IServiceCollection AddCustomRateLimiter(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.OnRejected = async (context, token) =>
                {
                    var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "desconocida";
                    context.HttpContext.Response.StatusCode = 429;
                    context.HttpContext.Response.ContentType = "application/json";
                    var mensaje = $"{{\"message\": \"Demasiadas peticiones desde la IP {ip}. Intenta más tarde.\"}}";
                    await context.HttpContext.Response.WriteAsync(mensaje, token);
                };

                // Aquí no se define GlobalLimiter
                options.AddPolicy("ipLimiter", httpContext =>
                {
                    var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
                    return RateLimitPartition.GetFixedWindowLimiter(ip, _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 5,
                        Window = TimeSpan.FromSeconds(10),
                        QueueLimit = 0,
                        QueueProcessingOrder = QueueProcessingOrder.OldestFirst
                    });
                });
            });

            return services;
        }

        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuration from AppSettings
            services.Configure<JWT>(configuration.GetSection("JWT"));

            //Adding Athentication - JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                    };
                });
        }

        public static void AddValidationErrors(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {

                    var errors = actionContext.ModelState.Where(u => u.Value.Errors.Count > 0)
                                                    .SelectMany(u => u.Value.Errors)
                                                    .Select(u => u.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidation()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
        }

    }
}