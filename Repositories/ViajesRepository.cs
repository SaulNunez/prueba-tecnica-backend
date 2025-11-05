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
        return context.Viajes.ToList();
    }
    public Viaje? GetViajeById(int id)
    {
        return context.Viajes.FirstOrDefault(v => v.Id == id);
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
            existingViaje.FechaSalida = viaje.FechaSalida;
            existingViaje.FechaLlegada = viaje.FechaLlegada;
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