using prueba_tecnica_backend.Models;

namespace prueba_tecnica_backend.Repositories;

public interface IRutaRepository
{
    void AddRuta(Ruta ruta);
    Ruta? GetRutaByOrigenDestino(string origen, string destino);
}

public class RutaRepository(ViajesDbContext context) : IRutaRepository
{
    public Ruta? GetRutaByOrigenDestino(string origen, string destino)
    {
        return context.Rutas.FirstOrDefault(r => r.Origen == origen && r.Destino == destino);
    }

    public void AddRuta(Ruta ruta)
    {
        context.Rutas.Add(ruta);
        context.SaveChanges();
    }
}