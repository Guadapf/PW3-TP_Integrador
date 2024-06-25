using Microsoft.AspNetCore.Mvc;
using Servicio;
using System.Text.Json;

namespace Nomina.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalarioBaseController : ControllerBase
{
    private readonly ISalarioBaseService _salarioBaseService;

    public SalarioBaseController(ISalarioBaseService salarioBaseService)
    {
        _salarioBaseService = salarioBaseService;
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

    [HttpPost("AgregarSalarioBase")]
    public async Task<IActionResult> AgregarSalarioBase([FromBody] JsonElement jsonElement)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            SalarioBase salarioBase = JsonSerializer.Deserialize<SalarioBase>(jsonElement);
            await _salarioBaseService.AgregarSalarioBase(salarioBase);
            return Ok(new { Message = "Salario Base agregado correctamente" });
        }catch(Exception ex)
        {
            var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Detalles no disponibles";
            return StatusCode(500, $"Error interno del servidor: {innerExceptionMessage}");
        }
    }

}

