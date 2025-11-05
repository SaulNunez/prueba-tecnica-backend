using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Models;

namespace prueba_tecnica_backend.Models;

public class ViajesDbContext(DbContextOptions<ViajesDbContext> options) : DbContext(options)
{
    public DbSet<Operador> Operadores { get; set; }
    public DbSet<Viaje> Viajes { get; set; }
    public DbSet<Ruta> Rutas { get; set; }
}