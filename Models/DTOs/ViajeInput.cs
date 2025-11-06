namespace prueba_tecnica_backend.Models.DTOs;

public record ViajeInput(
    int RutaId,
    DateTime FechaSalida,
    DateTime FechaLlegada,
    int OperadorId
    );