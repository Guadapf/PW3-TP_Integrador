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

        [HttpPost("AltaEmpleado")]
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

        [HttpPut]
        public async Task<IActionResult> ModificarEmpleado([FromBody] JsonElement jsonElement)
        {
            var jsonString = jsonElement.GetRawText();
            var client = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Put, "https://localhost:7252/api/empleado")
            {
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request);
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

        [HttpDelete]
        public async Task<IActionResult> EliminarEmpleado(int id)
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Delete,
                $"https://localhost:7252/api/Empleado/Eliminar/{id}")
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

        // Genero

        [HttpPost("AltaGenero")]
        public async Task<IActionResult> AltaGenero([FromBody] JsonElement jsonElement)
        {
            // Serialize the received JSON payload back to a string
            var jsonString = jsonElement.GetRawText();

            Console.WriteLine(jsonString);

            // Create HTTP client and request
            var client = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7252/api/genero")
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

        [HttpGet("GetGeneros")]
        public async Task<IActionResult> GetGeneros()
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                "https://localhost:7252/api/genero/GetGeneros")
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

        // País

        [HttpPost("AltaPais")]
        public async Task<IActionResult> AltaPais([FromBody] JsonElement jsonElement)
        {
            // Serialize the received JSON payload back to a string
            var jsonString = jsonElement.GetRawText();

            Console.WriteLine(jsonString);

            // Create HTTP client and request
            var client = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7252/api/pai")
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

        [HttpGet("GetPaises")]
        public async Task<IActionResult> GetPaises()
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                "https://localhost:7252/api/pai/GetPaises")
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

        // Departamento

        [HttpPost("AltaDepartamento")]
        public async Task<IActionResult> AltaDepartamento([FromBody] JsonElement jsonElement)
        {
            // Serialize the received JSON payload back to a string
            var jsonString = jsonElement.GetRawText();

            Console.WriteLine(jsonString);

            // Create HTTP client and request
            var client = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7252/api/departamento")
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

        [HttpGet("GetDepartamentos")]
        public async Task<IActionResult> GetDepartamentos()
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                "https://localhost:7252/api/departamento/GetDepartamentos")
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
    }
}
