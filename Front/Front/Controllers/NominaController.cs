using Front.Models;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers;

public class NominaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult DetalleEmpleado()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DetalleEmpleado(BusquedaModel parametro)
    {
        EmpleadoNominaModel model = new EmpleadoNominaModel()
        {
            Nombre = "Eduardo",
            Apellido = "Caracas",
            Edad = 12,
            Antiguedad = 14,
            GeneroDescripcion = "L",
            PaisDescripcion = "Argentina",
            DepartamentoDescripcion = "La Matanza",
            Base = 700000.00f,
            Compensacion = 1.25f,
            Bono = 50000.00f,
            Total = 925000.00f
        };
        List<EmpleadoNominaModel> empleados = new List<EmpleadoNominaModel>();
        empleados.Add(model);
        ViewBag.Resultados = empleados;
        ViewBag.Empleado = model;
        return View();
    }
}
