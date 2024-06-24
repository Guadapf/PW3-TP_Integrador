using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ApiGateway.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NominaController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public NominaController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> CalcularSalario(int idPais, int idDepartamento, DateOnly fechaIngreso)
    {
        try
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7254/CalcularSalario?idPais={idPais}&idDepartamento={idDepartamento}&fechaIngreso={fechaIngreso:yyyy-MM-dd}");

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var myClientINC = _httpClientFactory.CreateClient();
            var response = await myClientINC.SendAsync(httpRequestMessage);

            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return Content(content, "application/json");
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error al llamar al servicio de salario base.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocurrió un error al calcular el salario. Por favor, inténtelo de nuevo más tarde: {ex.Message}");
        }
    }

}
