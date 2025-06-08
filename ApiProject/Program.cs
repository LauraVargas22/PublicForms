using ApiProject.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
//Proporciona las clases de configuración de swagger
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using APIProject.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.AddControllers();
builder.Services.AddApplicationServices();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
// Configuración Swagger
builder.Services.AddEndpointsApiExplorer();   //Método para registrar los servicios necesarios para que Swagger explorar los endpoints de la API. 
//Configuración incial de Swagger
//AddSwaggerGen registra el generador de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

    // Configuramos cómo se ve el botón "Authorize" en Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Poné tu token así: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Obligamos a que Swagger use esta seguridad por default
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var secretKey = builder.Configuration["Jwt:Key"];

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    });

// Activamos autorización en general
builder.Services.AddAuthorization();

// Agregamos nuestro generador de tokens como servicio global
builder.Services.AddSingleton<TokenService>();


builder.Services.AddDbContext<PublicDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
    options.UseNpgsql(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var app = builder.Build();
// Activamos el middleware que revisa los tokens
app.UseAuthentication();

// Activamos el middleware que permite o bloquea según roles, claims, etc.
app.UseAuthorization();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    //app.UseSwagger() Habilita el middleware que genera el documento JSON de la API
    app.UseSwagger();
    //app.UseSwaggerUI() Configura la interfaz de usuario de Swagger
    app.UseSwaggerUI(c =>
    {
        //SwaggerEndpoint especifica la ruta del documento JSON de Swagger, "Project EF API v1" nombre de la API
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project EF API v1");
        //Define la ruta base para acceder a la interfaz de usuario
        c.RoutePrefix = "swagger";
    });
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.Run();
