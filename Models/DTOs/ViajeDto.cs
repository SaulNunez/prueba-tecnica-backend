namespace prueba_tecnica_backend.Models.DTOs;

public record ViajeDto(
    string Origen,
    string Destino,
    DateTime FechaSalida,
    DateTime FechaLlegada,
    string Operador,
    int Id = 0
    );