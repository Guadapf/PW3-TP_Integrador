using Entidades;
using Microsoft.AspNetCore.Mvc;
using Servicio;
using System.Text.Json;

namespace EmployeeService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartamentoController : ControllerBase
{
    private readonly IServicioDepartamento _departamentoService;

    public DepartamentoController(IServicioDepartamento departamentoService)
    {
        _departamentoService = departamentoService;
    }

    [HttpPost]
    public async Task<IActionResult> CargarDepartamento([FromBody] JsonElement jsonElement)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Departamento departamento = JsonSerializer.Deserialize<Departamento>(jsonElement);
            await _departamentoService.cargarDepartamento(departamento);
            return Ok(new { Message = "Departamento agregado correctamente." });
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Detalles no disponibles.";
            return StatusCode(500, $"Error interno del servidor: {innerExceptionMessage}");
        }
    }

    [HttpGet("GetDepartamentos")]
    public async Task<IActionResult> GetDepartamentos()
    {
        try
        {
            var departamentos = await _departamentoService.ObtenerDepartamentos();
            return Ok(departamentos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
}
