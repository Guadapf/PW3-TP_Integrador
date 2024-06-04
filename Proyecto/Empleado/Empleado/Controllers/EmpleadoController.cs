using Microsoft.AspNetCore.Mvc;
using Servicio;

namespace Empleado.Controllers
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

    public async Task<IActionResult> GetEmpleado()
    {
            // Simulación de la lógica para obtener la información del empleado
            _empleadoService.cargarEmpleado();
            string var = _empleadoService.ObtenerEmpleados();

        return Ok(var);
    }

    // Otros métodos CRUD
}
}
