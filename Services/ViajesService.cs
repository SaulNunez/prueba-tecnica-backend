using prueba_tecnica_backend.Models;
using prueba_tecnica_backend.Repositories;

namespace prueba_tecnica_backend.Services;

public class ViajeService(IViajeRepository repository)
{
    public List<Viaje> ObtenerListaViajes()
    {
        return repository.GetAllViajes();
    }
    public Viaje? ObtenerViajePorId(int id)
    {
        return repository.GetViajeById(id);
    }

    public void CrearViaje(Viaje viaje)
    {
        if (viaje == null)
        {
            throw new ArgumentNullException(nameof(viaje), "El viaje no puede ser nulo.");
        }
        if (viaje.FechaLlegada <= viaje.FechaSalida)
        {
            throw new ArgumentException("La fecha de llegada debe ser posterior a la fecha de salida.");
        }

        var nuevoViaje = new Viaje
        {
            FechaSalida = viaje.FechaSalida,
            FechaLlegada = viaje.FechaLlegada,
            OperadorId = viaje.OperadorId
        };
        repository.AddViaje(nuevoViaje);
    }
}