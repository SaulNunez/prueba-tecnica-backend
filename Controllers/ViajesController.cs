using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba_tecnica_backend.Services;

namespace prueba_tecnica_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesController(IViajeService viajeService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(viajeService.ObtenerListaViajes());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error occurred" });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var viaje = viajeService.ObtenerViajePorId(id);
                if (viaje == null)
                {
                    return NotFound();
                }
                return Ok(viaje);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error occurred" });
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Models.DTOs.ViajeInput viaje)
        {
            try
            {
                var nuevoId = viajeService.CrearViaje(viaje);
                return CreatedAtAction(nameof(GetById), new { id = nuevoId }, null);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error occurred" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Models.DTOs.ViajeInput viaje)
        {
            try
            {
                var viajeActualizado = viajeService.EditarViaje(viaje, id);
                if (viajeActualizado == null)
                {
                    return NotFound();
                }
                return Ok(viajeActualizado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error occurred" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                viajeService.EliminarViaje(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error occurred" });
            }
        }
    }
}
