using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiGateway.Controllers;

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
            $"https://localhost:7252/api/empleado/GetEmpleado/{id}")
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
        
    [HttpGet("GetEmpleados/{busqueda}")]
    public async Task<IActionResult> GetEmpleado(string busqueda)
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            $"https://localhost:7252/api/Empleado/GetEmpleados/{busqueda}")
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
        var jsonString = jsonElement.GetRawText();

        var client = _httpClient.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7252/api/empleado")
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

    [HttpDelete("EliminarEmpleado/{id}")]
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
        var jsonString = jsonElement.GetRawText();

        var client = _httpClient.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7252/api/genero")
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

    // Pa�s

    [HttpPost("AltaPais")]
    public async Task<IActionResult> AltaPais([FromBody] JsonElement jsonElement)
    {
        var jsonString = jsonElement.GetRawText();
        
        var client = _httpClient.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7252/api/pai")
        {
            Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
        };

        var response = await client.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();
  
        if (response.IsSuccessStatusCode)
        {
            var responseObject = JsonSerializer.Deserialize<JsonElement>(content);
            var id = responseObject.GetProperty("idPais").GetInt32();
            var salarioBase = jsonElement.GetProperty("SalarioBase").GetDecimal();

            await CargarSalarioBaseNomina(client, id, salarioBase);

            return Content(content, "application/json");
        }
        else
        {
            return StatusCode((int)response.StatusCode, "mission failed, we'll get 'em next time");
        }
    }

    private async Task<IActionResult> CargarSalarioBaseNomina(HttpClient cliente, int idPais, decimal salarioBase)
    {
        var payload = new
        {
            IdPais = idPais,
            Salario = salarioBase
        };
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        var payloadJson = JsonSerializer.Serialize(payload);

        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7254/api/salariobase")
        {
            Content = new StringContent(payloadJson, Encoding.UTF8, "application/json")
        };

        var response = await cliente.SendAsync(request);

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
        var jsonString = jsonElement.GetRawText();

        var client = _httpClient.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7252/api/departamento")
        {
            Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
        };

        var response = await client.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            /*
            var responseObject = JsonSerializer.Deserialize<JsonElement>(content);
            var id = responseObject.GetProperty("idPais").GetInt32();
            var salarioBase = jsonElement.GetProperty("SalarioBase").GetDecimal();

            await CargarSalarioBaseNomina(client, id, salarioBase);
            */

            var responseObject = JsonSerializer.Deserialize<JsonElement>(content);
            var id = responseObject.GetProperty("idDepartamento").GetInt32();
            var compensacion = jsonElement.GetProperty("Compensacion").GetDecimal();
            await CargarCompensacionNomina(client, id, compensacion);

            return Content(content, "application/json");
        }
        else
        {
            return StatusCode((int)response.StatusCode, "mission failed, we'll get 'em next time");
        }
    }

    private async Task<IActionResult> CargarCompensacionNomina(HttpClient cliente, int idDepartamento, decimal compensacion)
    {
        var payload = new
        {
            IdDepartamento = idDepartamento,
            Multiplicador = compensacion
        };
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        var payloadJson = JsonSerializer.Serialize(payload);

        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7254/api/compensacion")
        {
            Content = new StringContent(payloadJson, Encoding.UTF8, "application/json")
        };

        var response = await cliente.SendAsync(request);

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
