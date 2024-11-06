using Appplication_.Services;
using computosApp.Models.DB;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Agrego la inyección al context para que este disponibles en toda la app
//Paso al constructor la conexion a la base de datos
builder.Services.AddDbContext<HospitalComputosContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ServicioServices>();
builder.Services.AddScoped<TonerServices>();
builder.Services.AddScoped<EntregaTonerServices>();
builder.Services.AddScoped<ITonerRepository, TonerRepository>();
builder.Services.AddScoped<IEntregaTonerRespository, EntregaTonerRepository>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

