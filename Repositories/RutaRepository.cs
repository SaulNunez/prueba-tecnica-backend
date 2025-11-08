using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Models;

namespace prueba_tecnica_backend.Repositories;

public interface IRutaRepository
{
    void AddRuta(Ruta ruta);
    Ruta? GetRutaByOrigenDestino(string origen, string destino);
    Ruta? GetRutaById(int id);
    List<Ruta> GetRutas();
}

public class RutaRepository(ViajesDbContext context) : IRutaRepository
{
    public Ruta? GetRutaByOrigenDestino(string origen, string destino)
    {
        return context.Rutas.FirstOrDefault(r => r.Origen == origen && r.Destino == destino);
    }

    public Ruta? GetRutaById(int id)
    {
        //return context.Rutas.FirstOrDefault(r => r.Id == id);
        return context.Rutas.FromSql($"SELECT * FROM Rutas ORDER BY Origen LIMIT 1").FirstOrDefault();
    }

    public void AddRuta(Ruta ruta)
    {
        context.Rutas.Add(ruta);
        context.SaveChanges();
    }

    public List<Ruta> GetRutas()
    {
        //return context.Rutas.OrderBy(r => r.Origen).ToList();
        return context.Rutas.FromSql($"SELECT * FROM Rutas ORDER BY Origen").ToList();
    } 
}