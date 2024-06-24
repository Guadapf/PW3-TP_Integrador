using Microsoft.AspNetCore.Mvc;
using Servicio;

namespace Nomina.Controllers
{
    public class SalarioBaseController : Controller
    {
        private readonly ISalarioBaseService _salarioBaseService;

        public SalarioBaseController(ISalarioBaseService salarioBaseService)
        {
            _salarioBaseService = salarioBaseService;
        }


        [HttpGet("CalcularSalario")]
        public IActionResult CalcularSalario(int idPais, int idDepartamento, DateOnly fechaIngreso)
        {
            try
            {
                var salario = _salarioBaseService.CalcularSalario(idPais, idDepartamento, fechaIngreso);
                return Ok(salario);

            }catch(Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error al calcular el salario. Por favor, inténtelo de nuevo más tarde: {ex.Message}");
            }
        }
    }
}
