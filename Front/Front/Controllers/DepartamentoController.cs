using Front.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Front.Controllers;

public class DepartamentoController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DepartamentoController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult AltaDepartamento()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AltaDepartamento(AltaDepartamentoModel modelo)
    {
        if (!ModelState.IsValid)
            return View(modelo);

        var jsonEmpleado = JsonSerializer.Serialize(modelo);
        var contenido = new StringContent(jsonEmpleado, Encoding.UTF8, "application/json");

        var clienteHttp = _httpClientFactory.CreateClient();
        var mensajePeticionHttp = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7253/api/empleado/AltaDepartamento")
        {
            Content = contenido
        };

        var mensajeRespuesta = await clienteHttp.SendAsync(mensajePeticionHttp);

        if (mensajeRespuesta.IsSuccessStatusCode)
        {
            TempData["Message"] = "¡Departamento creado con éxito!";
        }
        else
        {
            TempData["StackTrace"] = "Error en la petición HTTP con el código: " + mensajeRespuesta.StatusCode;
        }

        return RedirectToAction("ListarDepartamentos");
    }

    public async Task<IActionResult> ListarDepartamentos()
    {
        /*
        List<DepartamentoModel> departamentos = new List<DepartamentoModel>();
        departamentos.Add(new DepartamentoModel { IdDepartamento = 1, Descripcion = "La Matanza" });
        departamentos.Add(new DepartamentoModel { IdDepartamento = 2, Descripcion = "Esquel" });
        */

        // Crear petición
        var mensajePeticionHttp = new HttpRequestMessage(
            HttpMethod.Get,
            "https://localhost:7253/api/empleado/GetDepartamentos")
        {
            Headers =
            {
                {"Accept", "application/json" },
                {"User-Agent", "HttpRequestsSample" }
            }
        };

        // Crear cliente HTTP
        var clienteHttp = _httpClientFactory.CreateClient();

        // Realizar petición y almacenar respuesta
        var mensajeRespuesta = await clienteHttp.SendAsync(mensajePeticionHttp);
        List<DepartamentoModel> departamentos = new List<DepartamentoModel>();

        // Desserialización   *- B E G I N S -*
        if (mensajeRespuesta.IsSuccessStatusCode)
        {
            try
            {
                string cadenaRespuesta = await mensajeRespuesta.Content.ReadFromJsonAsync<string>();

                if (!string.IsNullOrEmpty(cadenaRespuesta))
                {
                    departamentos = JsonSerializer.Deserialize<List<DepartamentoModel>>(cadenaRespuesta);

                    if (departamentos == null || departamentos.Count == 0)
                    {
                        TempData["Message"] = "Deserialization returned null or empty list.";
                    }
                }
            }
            catch (JsonException ex)
            {
                TempData["Message"] = "Error deserializing JSON: " + ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
            }
        }
        else
        {
            TempData["Message"] = "HTTP request failed with status code: " + mensajeRespuesta.StatusCode;
        }

        return View(departamentos);
    }
}
