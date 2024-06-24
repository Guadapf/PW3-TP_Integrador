using Front.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Front.Controllers;

public class PaisController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PaisController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult AltaPais()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AltaPais(AltaPaisModel modelo)
    {
        if (!ModelState.IsValid)
            return View(modelo);

        var jsonEmpleado = JsonSerializer.Serialize(modelo);
        var contenido = new StringContent(jsonEmpleado, Encoding.UTF8, "application/json");

        var clienteHttp = _httpClientFactory.CreateClient();
        var mensajePeticionHttp = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7253/api/empleado/AltaPais")
        {
            Content = contenido
        };

        var mensajeRespuesta = await clienteHttp.SendAsync(mensajePeticionHttp);

        if (mensajeRespuesta.IsSuccessStatusCode)
        {
            TempData["Message"] = "¡País creado con éxito!";
        }
        else
        {
            TempData["StackTrace"] = "Error en la petición HTTP con el código: " + mensajeRespuesta.StatusCode;
        }

        return RedirectToAction("ListarPaises");
    }

    public async Task<IActionResult> ListarPaises()
    {
        /*
        List<PaisModel> paises = new List<PaisModel>();
        paises.Add(new PaisModel { IdPais = 1, Descripcion = "Argentina (namber uan)" });
        paises.Add(new PaisModel { IdPais = 2, Descripcion = "República Popular China" });
        paises.Add(new PaisModel { IdPais = 3, Descripcion = "Unión de Repúblicas Socialistas Soviéticas" });
        */

        // Crear petición
        var mensajePeticionHttp = new HttpRequestMessage(
            HttpMethod.Get,
            "https://localhost:7253/api/empleado/GetPaises")
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
        List<PaisModel> paises = new List<PaisModel>();

        // Desserialización   *- B E G I N S -*
        if (mensajeRespuesta.IsSuccessStatusCode)
        {
            try
            {
                string cadenaRespuesta = await mensajeRespuesta.Content.ReadFromJsonAsync<string>();

                if (!string.IsNullOrEmpty(cadenaRespuesta))
                {
                    paises = JsonSerializer.Deserialize<List<PaisModel>>(cadenaRespuesta);

                    if (paises == null || paises.Count == 0)
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

        return View(paises);
    }
}
