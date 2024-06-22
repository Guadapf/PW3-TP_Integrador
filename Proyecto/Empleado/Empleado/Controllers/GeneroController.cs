using Microsoft.AspNetCore.Mvc;
using Servicio;
using Entidades;
using System.Text.Json;

namespace EmployeeService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GeneroController : ControllerBase
{
    private readonly IServicioGenero _generoService;

    public GeneroController(IServicioGenero generoService)
    {
        _generoService = generoService;
    }

    [HttpGet("GetGeneros")]
    public async Task<IActionResult> GetGeneros()
    {
        try
        {
            var generos = await _generoService.ObtenerGeneros();
            return Ok(generos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }

    }
}
