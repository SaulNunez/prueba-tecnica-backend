namespace prueba_tecnica_backend.Models;

public class Viaje
{
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int OperadorId { get; set; }
    public Operador Operador { get; set; }
    public int RutaId { get; set; }
    public Ruta Ruta { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}