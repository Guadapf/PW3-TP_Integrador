using Microsoft.AspNetCore.Mvc;
using Servicio;
using Entidades;
using System.Text.Json;

namespace EmployeeService.Controllers
{
[Route("api/[controller]")]
    [ApiController]
public class EmpleadoController : ControllerBase
{

        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet("GetEmpleados")]
        public async Task<IActionResult> GetEmpleados()
        {
            try
            {
                var empleados = await _empleadoService.ObtenerEmpleados();
                return Ok(empleados);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
            
        }

        [HttpGet("GetEmpleado/{id}")]
        public async Task<IActionResult> GetEmpleado(int id)
        {
            try
            {
                var empleado = await _empleadoService.ObtenerEmpleadoPorId(id);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CargarEmpleado([FromBody] JsonElement jsonElement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Empleado empleado = JsonSerializer.Deserialize<Empleado>(jsonElement);
                await _empleadoService.cargarEmpleado(empleado);
                return Ok(new { Message = "Empleado agregado correctamente" });
            }
            catch (Exception ex)
            {
                var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Detalles no disponibles";
                return StatusCode(500, $"Error interno del servidor: {innerExceptionMessage}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmpleado([FromBody] Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _empleadoService.ActualizarEmpleado(empleado);
                return Ok(new { Message = "Empleado actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            try
            {
                await _empleadoService.EliminarEmpleado(id);
                return Ok(new { Message = "Empleado eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        /*[HttpGet]
    public async Task<IActionResult> GetEmpleado()
    {
            // Simulación de la lógica para obtener la información del empleado
            _empleadoService.cargarEmpleado();
            string var = _empleadoService.ObtenerEmpleados();

        return Ok(var);
    }*/

    // Otros métodos CRUD
}
}
