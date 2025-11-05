namespace prueba_tecnica_backend.Models;

public class Ruta
{
    public int Id { get; set; }
    public string Origen { get; set; }
    public string Destino { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}