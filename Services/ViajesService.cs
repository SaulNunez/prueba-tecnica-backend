using prueba_tecnica_backend.Models;
using prueba_tecnica_backend.Models.DTOs;
using prueba_tecnica_backend.Repositories;

namespace prueba_tecnica_backend.Services;

public interface IViajeService
{
    int CrearViaje(ViajeInput viaje);
    ViajeDto EditarViaje(ViajeInput viaje, int id);
    List<ViajeDto> ObtenerListaViajes();
    ViajeDto? ObtenerViajePorId(int id);
    void EliminarViaje(int id);
}

public class ViajeService(IViajeRepository repository, IOperadorRepository operadorRepository, IRutaRepository rutaRepository) : IViajeService
{
    public List<ViajeDto> ObtenerListaViajes()
    {
        var viajes = repository.GetAllViajes();
        return viajes.Select(v => new ViajeDto(
            v.Ruta.Origen, v.Ruta.Destino, v.FechaSalida,
            v.FechaLlegada, v.Operador.Nombre, v.Id))
            .ToList();
    }
    public ViajeDto? ObtenerViajePorId(int id)
    {
        var viaje = repository.GetViajeById(id);

        if (viaje == null)
        {
            return null;
        }

        return new ViajeDto(
            viaje.Ruta.Origen,
            viaje.Ruta.Destino,
            viaje.FechaSalida,
            viaje.FechaLlegada,
            viaje.Operador.Nombre,
            viaje.Id
        );
    }

    public int CrearViaje(ViajeInput viaje)
    {
        if (viaje == null)
        {
            throw new ArgumentNullException(nameof(viaje), "El viaje no puede ser nulo.");
        }
        if (viaje.FechaLlegada <= viaje.FechaSalida)
        {
            throw new ArgumentException("La fecha de llegada debe ser posterior a la fecha de salida.");
        }

        var operadorExistente = operadorRepository.GetById(viaje.OperadorId) ?? throw new ArgumentException("El operador especificado no existe.");
        var rutaExistente = rutaRepository.GetRutaById(viaje.RutaId) ?? throw new ArgumentException("La ruta especificada no existe.");
        var nuevoViaje = new Viaje
        {
            FechaSalida = viaje.FechaSalida,
            FechaLlegada = viaje.FechaLlegada,
            OperadorId = operadorExistente.Id,
            RutaId = rutaExistente.Id
        };
        repository.AddViaje(nuevoViaje);
        return nuevoViaje.Id;
    }

    public ViajeDto EditarViaje(ViajeInput viaje, int id)
    {
        var viajeDb = repository.GetViajeById(id) ?? throw new KeyNotFoundException($"No se encontró un viaje con ID {id}.");
        if (viaje == null)
        {
            throw new ArgumentNullException(nameof(viaje), "El viaje no puede ser nulo.");
        }
        if (viaje.FechaLlegada <= viaje.FechaSalida)
        {
            throw new ArgumentException("La fecha de llegada debe ser posterior a la fecha de salida.");
        }

        var operadorExistente = operadorRepository.GetById(viaje.OperadorId) ?? throw new ArgumentException("El operador especificado no existe.");
        var rutaExistente = rutaRepository.GetRutaById(viaje.RutaId) ?? throw new ArgumentException("La ruta especificada no existe.");

        viajeDb.FechaSalida = viaje.FechaSalida;
        viajeDb.FechaLlegada = viaje.FechaLlegada;
        viajeDb.OperadorId = operadorExistente.Id;
        viajeDb.RutaId = rutaExistente.Id;

        repository.UpdateViaje(viajeDb, id);

        return new ViajeDto(
            viajeDb.Ruta.Origen,
            viajeDb.Ruta.Destino,
            viajeDb.FechaSalida,
            viajeDb.FechaLlegada,
            viajeDb.Operador.Nombre,
            viajeDb.Id
        );
    }

    public void EliminarViaje(int id)
    {
        repository.DeleteViaje(id);
    }
}