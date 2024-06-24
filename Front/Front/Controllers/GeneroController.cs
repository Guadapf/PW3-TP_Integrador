using Front.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Front.Controllers;

public class GeneroController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GeneroController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult AltaGenero()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AltaGenero(AltaGeneroModel modelo)
    {
        if (!ModelState.IsValid)
            return View(modelo);

        var jsonEmpleado = JsonSerializer.Serialize(modelo);
        var contenido = new StringContent(jsonEmpleado, Encoding.UTF8, "application/json");

        var clienteHttp = _httpClientFactory.CreateClient();
        var mensajePeticionHttp = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7253/api/empleado/AltaGenero")
        {
            Content = contenido
        };

        var mensajeRespuesta = await clienteHttp.SendAsync(mensajePeticionHttp);

        if (mensajeRespuesta.IsSuccessStatusCode)
        {
            TempData["Message"] = "¡Género creado con éxito!";
        }
        else
        {
            TempData["StackTrace"] = "Error en la petición HTTP con el código: " + mensajeRespuesta.StatusCode;
        }

        return RedirectToAction("ListarGeneros");
    }

    public async Task<IActionResult> ListarGeneros()
    {

        // Crear petición
        var mensajePeticionHttp = new HttpRequestMessage(
            HttpMethod.Get,
            "https://localhost:7253/api/empleado/GetGeneros")
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
        List<GeneroModel> generos = new List<GeneroModel>();

        if (mensajeRespuesta.IsSuccessStatusCode)
        {
            try
            {
                string cadenaRespuesta = await mensajeRespuesta.Content.ReadFromJsonAsync<string>();

                if (!string.IsNullOrEmpty(cadenaRespuesta))
                {
                    generos = JsonSerializer.Deserialize<List<GeneroModel>>(cadenaRespuesta);

                    if (generos == null || generos.Count == 0)
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

        return View(generos);
    }
}
