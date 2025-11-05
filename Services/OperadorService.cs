using prueba_tecnica_backend.Models;
using prueba_tecnica_backend.Repositories;

public interface IOperadorService
{
    List<Operador> ObtenerListaOperadores();
}

public class OperadorService(IOperadorRepository repository) : IOperadorService
{
    public List<Operador> ObtenerListaOperadores()
    {
        return repository.GetAllOperadores();
    }
}