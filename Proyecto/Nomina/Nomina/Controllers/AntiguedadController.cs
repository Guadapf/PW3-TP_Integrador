using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio;
using System.Text.Json;

namespace Nomina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AntiguedadController : ControllerBase
    {
        private readonly IAntiguedadService _antiguedadService;

        public AntiguedadController(IAntiguedadService antiguedadService)
        {
            _antiguedadService = antiguedadService;
        }

        [HttpGet("ObtenerAntiguedades")]
        public async Task<IActionResult> ObtenerAntiguedades()
        {
            try
            {
                var antiguedades = await _antiguedadService.ObtenerAntiguedades();
                return Ok(antiguedades);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocurrió un error al obtener las antigüedades. Por favor, inténtelo de nuevo más tarde: {ex.Message}");
            }
        }

        [HttpPost("AgregarAntiguedad")]
        public async Task<IActionResult> AgregarAntiguedad([FromBody] JsonElement jsonElement)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Antiguedad antiguedad = JsonSerializer.Deserialize<Antiguedad>(jsonElement);
                await _antiguedadService.AgregarAntiguedad(antiguedad);
                return Ok(new { Message = "Antigüedad agregada correctamente" });
            }
            catch (Exception ex)
            {
                var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Detalles no disponibles";
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {innerExceptionMessage}");
            }
        }
    }
}
