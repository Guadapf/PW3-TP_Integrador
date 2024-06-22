using Microsoft.AspNetCore.Mvc;
using Servicio;

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
