using prueba_tecnica_backend.Models;

namespace prueba_tecnica_backend.Repositories;

public class OperadorRepository(ViajesDbContext context)
{
    public List<Operador> GetAllOperadores()
    {
        return context.Operadores.ToList();
    }
}