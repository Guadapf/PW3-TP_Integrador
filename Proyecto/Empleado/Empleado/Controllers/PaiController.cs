using Entidades;
using Microsoft.AspNetCore.Mvc;
using Servicio;
using System.Text.Json;

namespace EmployeeService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaiController : ControllerBase
{
    private readonly IServicioPai _paiService;

    public PaiController(IServicioPai paiService)
    {
        _paiService = paiService;
    }

    [HttpPost]
    public async Task<IActionResult> CargarPais([FromBody] JsonElement jsonElement)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Pai pais = JsonSerializer.Deserialize<Pai>(jsonElement);
            await _paiService.cargarPai(pais);
            return Ok(new { Message = "País agregado correctamente." });
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Detalles no disponibles.";
            return StatusCode(500, $"Error interno del servidor: {innerExceptionMessage}");
        }
    }

    [HttpGet("GetPaises")]
    public async Task<IActionResult> GetPaises()
    {
        try
        {
            var paises = await _paiService.ObtenerPaises();
            return Ok(paises);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
}
