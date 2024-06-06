using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClient;

        public EmpleadoController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerEmpleados()
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                "https://localhost:7252/api/empleado")  
            {
                Headers =
                {
                    {"Accept", "application/json" },
                    {"User-Agent", "HttpRequestsSample" }
                }
            };

            var myClientINC = _httpClient.CreateClient();
            var response = await myClientINC.SendAsync(httpRequestMessage);

            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return Content(content, "application/json");
            }
            else
            {
                return StatusCode((int)response.StatusCode, "mission failed, we'll get 'em next time");
            }

        }
         
        // Otros métodos para CRUD de Empleados
    }
}
