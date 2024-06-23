using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                "https://localhost:7254/api/nomina/CalcularSalario?IdPais=idPais&IdDepartamento=idDepartamento&FechaIngreso=fechaIngreso")
        {
            Headers =
                {
                    {"Accept", "application/json" },
                    {"User-Agent", "HttpRequestsSample" }
                }
        };

        var myClientINC = _httpClientFactory.CreateClient();
        var response = myClientINC.Send(httpRequestMessage);

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
