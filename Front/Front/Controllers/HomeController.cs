using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
