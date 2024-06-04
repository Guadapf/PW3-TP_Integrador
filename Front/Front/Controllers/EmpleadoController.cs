using Front.Models;
using Microsoft.AspNetCore.Mvc;
using Servicio;
using System.Diagnostics;

namespace Front.Controllers
{
    public class EmpleadoController : Controller
    {

        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        public async Task<IActionResult> Details()
        {
            var empleado = await _empleadoService.GetEmpleadoAsync();
            return View(empleado);
        }

    }
}
