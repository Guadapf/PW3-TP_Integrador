using Front.Models;
using Microsoft.AspNetCore.Mvc;
using Servicio;
using System.Diagnostics;

namespace Front.Controllers
{
    public class EmpleadoController : Controller
    {

        private readonly EmpleadoService _empleadoService;

        public EmpleadoController(EmpleadoService empleadoService)
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
