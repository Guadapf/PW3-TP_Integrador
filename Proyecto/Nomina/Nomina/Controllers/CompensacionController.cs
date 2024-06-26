using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio;
using System.Text.Json;

namespace Nomina.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompensacionController : ControllerBase
{
    private readonly ICompensacionService _compensacionService;

    public CompensacionController(ICompensacionService compensacionService)
    {
        _compensacionService = compensacionService;
    }

    [HttpGet("ObtenerCompensaciones")]
    public async Task<IActionResult> ObtenerCompensaciones()
    {
        try
        {
            var compensaciones = await _compensacionService.ObtenerCompensaciones();
            return Ok(compensaciones);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocurrió un error al obtener las compensaciones. Por favor, inténtelo de nuevo más tarde: {ex.Message}");

        }
    }

    [HttpPost]
    public async Task<IActionResult> AgregarCompensacion([FromBody] JsonElement jsonElement)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var compensacion = JsonSerializer.Deserialize<Compensacion>(jsonElement.ToString());
            if (compensacion == null)
            {
                return BadRequest("Payload inválida");
            }

            await _compensacionService.AgregarCompensacion(compensacion);
            return Ok(new { Message = "Compensación agregado correctamente" });
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Detalles no disponibles";
            return StatusCode(500, $"Error interno del servidor: {innerExceptionMessage}");
        }
    }
}
