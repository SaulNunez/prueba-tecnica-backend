using prueba_tecnica_backend.Models;
using prueba_tecnica_backend.Repositories;

public class OperadorService(OperadorRepository repository)
{
    public List<Operador> ObtenerListaOperadores()
    {
        return repository.GetAllOperadores();
    }
}