using System.Reflection;
using ApiProject.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
//Proporciona las clases de configuración de swagger
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services.ConfigureCors();
builder.Services.AddApplicationServices();
builder.Services.AddCustomRateLimiter();

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
// Configuración Swagger
builder.Services.AddEndpointsApiExplorer();   //Método para registrar los servicios necesarios para que Swagger explorar los endpoints de la API. 
//Configuración incial de Swagger
//AddSwaggerGen registra el generador de Swagger
builder.Services.AddSwaggerGen(c =>
{
    //SwaggerDoc define la documentación de la API, "v1" es el identificador de la versión de la API, OpenApiInfo contiene la información general de la API.
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Project EF API",
        Version = "v1",
        Description = "API para el proyecto EF",
        Contact = new OpenApiContact
        {
            Name = "Grupo J1",
            Email = "laura.vargasr@colpre.edu.co"
        }
    });
});

builder.Services.AddDbContext<PublicDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
    options.UseNpgsql(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var app = builder.Build();
//app.MapControllers();
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
app.UseRateLimiter();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();