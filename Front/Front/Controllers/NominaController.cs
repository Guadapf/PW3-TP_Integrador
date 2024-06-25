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
}
