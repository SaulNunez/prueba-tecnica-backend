namespace prueba_tecnica_backend.Models;

public class Viaje
{
    public int Id { get; set; }
    public DateTime FechaSalida { get; set; }
    public DateTime FechaLlegada { get; set; }
    public int OperadorId { get; set; }
}