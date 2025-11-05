using prueba_tecnica_backend.Models;

namespace prueba_tecnica_backend.Repositories;

public interface IOperadorRepository
{
    List<Operador> GetAllOperadores();
    Operador? GetOperadorByName(string name);
    void AddOperador(Operador operador);
}

public class OperadorRepository(ViajesDbContext context) : IOperadorRepository
{
    public List<Operador> GetAllOperadores()
    {
        return context.Operadores.ToList();
    }

    public Operador? GetOperadorByName(string name)
    {
        return context.Operadores.FirstOrDefault(o => o.Nombre == name);
    }

    public void AddOperador(Operador operador)
    {
        context.Operadores.Add(operador);
        context.SaveChanges();
    }
}