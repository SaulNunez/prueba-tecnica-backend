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
            entity.HasData(
                new Operador { Id = 1, Nombre = "Star Tours" },
                new Operador { Id = 2, Nombre = "Viajes López" },
                new Operador { Id = 3, Nombre = "Transportes Ya" },
                new Operador { Id = 4, Nombre = "Limousines Centella"}
            );
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Origen).IsRequired();
            entity.Property(e => e.Destino).IsRequired();
            entity.Property(e => e.CreatedAt)
                  .HasDefaultValue(DateTimeOffset.UtcNow)
                  .ValueGeneratedOnAdd();
            entity.HasData(
                new Ruta { Id = 1, Origen = "Chihuahua", Destino = "Delicias" },
                new Ruta { Id = 2, Origen = "Juárez", Destino = "Chihuahua" },
                new Ruta { Id = 3, Origen = "Delicias", Destino = "Juárez" },
                new Ruta { Id = 4, Origen = "Delicias", Destino = "Chihuahua" },
                new Ruta { Id = 5, Origen = "Chihuahua", Destino = "Juárez" },
                new Ruta { Id = 6, Origen = "Juárez", Destino = "Delicias" },
                new Ruta { Id = 7, Origen = "Chihuahua", Destino = "Ciudad de México" },
                new Ruta { Id = 8, Origen = "Ciudad de México", Destino = "Chihuahua" },
                new Ruta { Id = 9, Origen = "Juárez", Destino = "Ciudad de México" },
                new Ruta { Id = 10, Origen = "Ciudad de México", Destino = "Juárez" }
            );
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