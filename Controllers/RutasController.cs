using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba_tecnica_backend.Services;

namespace prueba_tecnica_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RutasController(IRutasService rutasService) : ControllerBase
{
    [HttpGet]
    public IActionResult ObtenerRutas()
    {
        try
        {
            return Ok(rutasService.ObtenerListaDeRutas());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error occurred" });
        }
    }
}

