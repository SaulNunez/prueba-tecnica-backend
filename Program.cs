using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Models;
using prueba_tecnica_backend.Repositories;
using prueba_tecnica_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ViajesDbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IOperadorRepository, OperadorRepository>();
builder.Services.AddScoped<IRutaRepository, RutaRepository>();
builder.Services.AddScoped<IViajeRepository, ViajeRepository>();
builder.Services.AddScoped<IViajeService, ViajeService>();
builder.Services.AddScoped<IOperadorService, OperadorService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
