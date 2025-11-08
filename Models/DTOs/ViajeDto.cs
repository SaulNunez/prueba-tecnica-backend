namespace prueba_tecnica_backend.Models.DTOs;

public record ViajeDto(
    string Origen,
    string Destino,
    DateTime FechaInicio,
    DateTime FechaFin,
    string Operador,
    int Id,
    int IdRuta,
    int IdOperador
    );