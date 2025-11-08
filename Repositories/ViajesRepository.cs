using Microsoft.EntityFrameworkCore;
using prueba_tecnica_backend.Models;

namespace prueba_tecnica_backend.Repositories;

public interface IViajeRepository
{
    void AddViaje(Viaje viaje);
    void DeleteViaje(int id);
    List<Viaje> GetAllViajes();
    Viaje? GetViajeById(int id);
    void UpdateViaje(Viaje viaje, int id);
}

public class ViajeRepository(ViajesDbContext context) : IViajeRepository
{
    public List<Viaje> GetAllViajes()
    {
        return context.Viajes.Include(v => v.Ruta).Include(v => v.Operador).ToList();
    }
    public Viaje? GetViajeById(int id)
    {
        return context.Viajes.Include(v => v.Ruta).Include(v => v.Operador).FirstOrDefault(v => v.Id == id);
    }

    public void AddViaje(Viaje viaje)
    {
        context.Viajes.Add(viaje);
        context.SaveChanges();
    }

    public void UpdateViaje(Viaje viaje, int id)
    {
        var existingViaje = context.Viajes.FirstOrDefault(v => v.Id == id);
        if (existingViaje != null)
        {
            existingViaje.FechaInicio = viaje.FechaInicio;
            existingViaje.FechaFin = viaje.FechaFin;
            existingViaje.OperadorId = viaje.OperadorId;
            context.SaveChanges();
        }
    }

    public void DeleteViaje(int id)
    {
        var viaje = context.Viajes.FirstOrDefault(v => v.Id == id);
        if (viaje != null)
        {
            context.Viajes.Remove(viaje);
            context.SaveChanges();
        }
    }
}