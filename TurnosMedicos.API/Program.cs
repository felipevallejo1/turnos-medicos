using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TurnosMedicos.Application.Interfaces;
using TurnosMedicos.Application.Service;
using TurnosMedicos.Core.Interfaces;
using TurnosMedicos.Infrastructure.Data;
using TurnosMedicos.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositorios y servicios
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Visitable en /swagger
}

// Middlewares
app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();
app.Run();
