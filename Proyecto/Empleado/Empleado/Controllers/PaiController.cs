using Microsoft.AspNetCore.Mvc;
using Servicio;

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
