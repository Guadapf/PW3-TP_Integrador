using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public EmpleadoController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerEmpleados()
        {
            var response = await _httpClient.GetAsync($"http://localhost:5009/api/empleado/");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, response.Content.Headers.ContentType.ToString());
        }
         
        // Otros métodos para CRUD de Empleados
    }
}
