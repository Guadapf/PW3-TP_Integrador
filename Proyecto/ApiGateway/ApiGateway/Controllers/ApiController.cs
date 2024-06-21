using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

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

        [HttpGet("GetEmpleados")]
        public async Task<IActionResult> GetEmpleados()
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                "https://localhost:7252/api/empleado/GetEmpleados")  
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
        
        [HttpGet("GetEmpleado/{id}")]
        public async Task<IActionResult> GetEmpleado(int id)
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7252/api/Empleado/GetEmpleado/{id}")
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

        [HttpPost]
        public async Task<IActionResult> CrearEmpleado([FromBody] JsonElement jsonElement)
        {
            // Serialize the received JSON payload back to a string
            var jsonString = jsonElement.GetRawText();

            Console.WriteLine(jsonString);

            // Create HTTP client and request
            var client = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7252/api/empleado")
            {
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };

            // Send the request
            var response = await client.SendAsync(request);

            // Get response content
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
