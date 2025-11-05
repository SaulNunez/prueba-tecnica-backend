using prueba_tecnica_backend.Models;
using prueba_tecnica_backend.Models.DTOs;
using prueba_tecnica_backend.Repositories;

namespace prueba_tecnica_backend.Services;

public interface IViajeService
{
    int CrearViaje(ViajeDto viaje);
    ViajeDto EditarViaje(ViajeDto viaje, int id);
    List<Viaje> ObtenerListaViajes();
    ViajeDto? ObtenerViajePorId(int id);
    void EliminarViaje(int id);
}

public class ViajeService(IViajeRepository repository, IOperadorRepository operadorRepository, IRutaRepository rutaRepository) : IViajeService
{
    public List<Viaje> ObtenerListaViajes()
    {
        return repository.GetAllViajes();
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

    public int CrearViaje(ViajeDto viaje)
    {
        if (viaje.Origen == "" || viaje.Destino == "")
        {
            throw new ArgumentException("El origen y destino no pueden estar vacíos.");
        }
        if (viaje == null)
        {
            throw new ArgumentNullException(nameof(viaje), "El viaje no puede ser nulo.");
        }
        if (viaje.FechaLlegada <= viaje.FechaSalida)
        {
            throw new ArgumentException("La fecha de llegada debe ser posterior a la fecha de salida.");
        }

        var operadorExistente = operadorRepository.GetOperadorByName(viaje.Operador.Trim());
        if (operadorExistente == null)
        {
            operadorExistente = new Operador { Nombre = viaje.Operador.Trim() };
            operadorRepository.AddOperador(operadorExistente);
        }

        var rutaExistente = rutaRepository.GetRutaByOrigenDestino(viaje.Origen.Trim(), viaje.Destino.Trim());
        if (rutaExistente == null)
        {
            rutaExistente = new Ruta { Origen = viaje.Origen.Trim(), Destino = viaje.Destino.Trim() };
            rutaRepository.AddRuta(rutaExistente);
        }

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

    public ViajeDto EditarViaje(ViajeDto viaje, int id)
    {
        var viajeDb = repository.GetViajeById(id);
        if (viajeDb == null)
        {
            throw new KeyNotFoundException($"No se encontró un viaje con ID {id}.");
        }

        if (viaje.Origen == "" || viaje.Destino == "")
        {
            throw new ArgumentException("El origen y destino no pueden estar vacíos.");
        }
        if (viaje == null)
        {
            throw new ArgumentNullException(nameof(viaje), "El viaje no puede ser nulo.");
        }
        if (viaje.FechaLlegada <= viaje.FechaSalida)
        {
            throw new ArgumentException("La fecha de llegada debe ser posterior a la fecha de salida.");
        }

        var operadorExistente = operadorRepository.GetOperadorByName(viaje.Operador.Trim());
        if (operadorExistente == null)
        {
            operadorExistente = new Operador { Nombre = viaje.Operador.Trim() };
            operadorRepository.AddOperador(operadorExistente);
        }

        var rutaExistente = rutaRepository.GetRutaByOrigenDestino(viaje.Origen.Trim(), viaje.Destino.Trim());
        if (rutaExistente == null)
        {
            rutaExistente = new Ruta { Origen = viaje.Origen.Trim(), Destino = viaje.Destino.Trim() };
            rutaRepository.AddRuta(rutaExistente);
        }

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