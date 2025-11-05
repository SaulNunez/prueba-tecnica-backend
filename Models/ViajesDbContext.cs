using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Models;

namespace prueba_tecnica_backend.Models;

public class ViajesDbContext(DbContextOptions<ViajesDbContext> options) : DbContext(options)
{
    public DbSet<Operador> Operadores { get; set; }
    public DbSet<Viaje> Viajes { get; set; }
    public DbSet<Ruta> Rutas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Operador>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired();
            entity.Property(e => e.CreatedAt)
                  .HasDefaultValue(DateTimeOffset.UtcNow)
                  .ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Origen).IsRequired();
            entity.Property(e => e.Destino).IsRequired();
            entity.Property(e => e.CreatedAt)
                  .HasDefaultValue(DateTimeOffset.UtcNow)
                  .ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FechaSalida).IsRequired();
            entity.Property(e => e.FechaLlegada).IsRequired();
            entity.Property(e => e.CreatedAt)
                  .HasDefaultValue(DateTimeOffset.UtcNow)
                  .ValueGeneratedOnAdd();

            entity.HasOne(e => e.Operador)
                  .WithMany()
                  .HasForeignKey(e => e.OperadorId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Ruta)
                  .WithMany()
                  .HasForeignKey(e => e.RutaId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}