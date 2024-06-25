using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio;

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
}
