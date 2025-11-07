using prueba_tecnica_backend.Models;
using prueba_tecnica_backend.Repositories;

namespace prueba_tecnica_backend.Services;

public interface IRutasService
{
    List<Ruta> ObtenerListaDeRutas();
}

public class RutasService(IRutaRepository repository) : IRutasService
{
    public List<Ruta> ObtenerListaDeRutas()
    {
        return repository.GetRutas();
    }
}