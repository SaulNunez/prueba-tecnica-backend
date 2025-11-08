using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace prueba_tecnica_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperadoresController(IOperadorService operadorService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOperadores()
        {
            try
            {
                return Ok(operadorService.ObtenerListaOperadores());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error occurred" });
            }
        }
    }
}
