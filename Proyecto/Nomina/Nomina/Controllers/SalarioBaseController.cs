using Microsoft.AspNetCore.Mvc;
using Servicio;
using System.Text.Json;

namespace Nomina.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalarioBaseController : ControllerBase
{
    private readonly ISalarioBaseService _salarioBaseService;
    private readonly ILogger<SalarioBaseController> _logger;

    public SalarioBaseController(ISalarioBaseService salarioBaseService, ILogger<SalarioBaseController> logger)
    {
        _salarioBaseService = salarioBaseService;
        _logger = logger;
    }


    [HttpGet("CalcularSalario")]
    public async Task<IActionResult> CalcularSalario(int idPais, int idDepartamento, DateOnly fechaIngreso)
    {
        try
        {
            var salario = await _salarioBaseService.CalcularSalario(idPais, idDepartamento, fechaIngreso);
            return Ok(salario);

        }catch(Exception ex)
        {
            return StatusCode(500, $"Ocurrió un error al calcular el salario. Por favor, inténtelo de nuevo más tarde: {ex.Message}");
        }
    }

    [HttpGet("ObtenerSalariosBase")]
    public async Task<IActionResult> ObtenerSalariosBase()
    {
        try
        {
            var salariosBase = await _salarioBaseService.ObtenerSalariosBase();
            return Ok(salariosBase);
        }catch(Exception ex)
        {
            return StatusCode(500, $"Ocurrio un error al obtener los salarios. Por favor, intántelo de nuevo más tarde: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AgregarSalarioBase([FromBody] JsonElement jsonElement)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var salarioBaseEnt = JsonSerializer.Deserialize<SalarioBase>(jsonElement.ToString());
            if (salarioBaseEnt == null)
            {
                _logger.LogError("Deserialization of SalarioBase failed");
                return BadRequest("Invalid payload");
            }

            _logger.LogInformation($"Deserialized SalarioBase: {salarioBaseEnt.IdPais}, {salarioBaseEnt.Salario}");
            await _salarioBaseService.AgregarSalarioBase(salarioBaseEnt);
            return Ok(new { Message = "Salario Base agregado correctamente" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding SalarioBase");
            var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Detalles no disponibles";
            return StatusCode(500, $"Error interno del servidor: {innerExceptionMessage}");
        }
    }

}

