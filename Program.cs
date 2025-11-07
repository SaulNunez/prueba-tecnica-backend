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
builder.Services.AddScoped<IRutasService, RutasService>();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAngularClient",
            builder => builder.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod());
    });

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
    InitializeDb(app);
}

app.UseCors("AllowAngularClient");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void InitializeDb(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    using var context = scope.ServiceProvider.GetService<ViajesDbContext>();
    if(context == null)
    {
        Console.WriteLine($"No se pudo encontrar en DI el contexto {nameof(ViajesDbContext)}, puede que no se inicialize correctamente la base de datos!");
    }
    context?.Database.Migrate();
}
