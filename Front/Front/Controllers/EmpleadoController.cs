using Front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Servicio;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Front.Controllers;

public class EmpleadoController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IEmpleadoService _empleadoService;

    public EmpleadoController(IHttpClientFactory httpClientFactory, IEmpleadoService empleadoService)
    {
        _httpClientFactory = httpClientFactory;
        _empleadoService = empleadoService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details()
    {
        var clienteHttp = _httpClientFactory.CreateClient();
        List<EmpleadoModel> empleados = await ListarModelo<EmpleadoModel>(clienteHttp, "https://localhost:7253/api/empleado/GetEmpleados");

        var generosTask = ListarModelo<GeneroModel>(clienteHttp, "https://localhost:7253/api/empleado/GetGeneros");
        var paisesTask = ListarModelo<PaisModel>(clienteHttp, "https://localhost:7253/api/empleado/GetPaises");
        var departamentosTask = ListarModelo<DepartamentoModel>(clienteHttp, "https://localhost:7253/api/empleado/GetDepartamentos");

        await Task.WhenAll(generosTask, paisesTask, departamentosTask);

        var generos = await generosTask;
        var paises = await paisesTask;
        var departamentos = await departamentosTask;

        foreach (var empleado in empleados)
        {
            empleado.GeneroDescripcion = generos.FirstOrDefault(g => g.IdGenero == empleado.IdGenero)?.Descripcion;
            empleado.PaisDescripcion = paises.FirstOrDefault(p => p.IdPais == empleado.IdPais)?.Descripcion;
            empleado.DepartamentoDescripcion = departamentos.FirstOrDefault(d => d.IdDepartamento == empleado.IdDepartamento)?.Descripcion;

            try
            {
                empleado.Salario = await ObtenerSalarioEmpleado(clienteHttp, empleado.IdPais, empleado.IdDepartamento, empleado.FechaIngreso);
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Error al obtener el salario del empleado {empleado.Nombre} {empleado.Apellido}: {ex.Message}";
                empleado.Salario = 0; 
            }
        }

        return View(empleados);
    }

    public async Task<IActionResult> CrearEmpleado()
    {
        var clienteHttp = _httpClientFactory.CreateClient();

        var generosTask = ListarModelo<GeneroModel>(clienteHttp, "https://localhost:7253/api/empleado/GetGeneros");
        var paisesTask = ListarModelo<PaisModel>(clienteHttp, "https://localhost:7253/api/empleado/GetPaises");
        var departamentosTask = ListarModelo<DepartamentoModel>(clienteHttp, "https://localhost:7253/api/empleado/GetDepartamentos");

        await Task.WhenAll(generosTask, paisesTask, departamentosTask);

        ViewBag.generos = new SelectList(await generosTask, "IdGenero", "Descripcion");
        ViewBag.paises = new SelectList(await paisesTask, "IdPais", "Descripcion");
        ViewBag.departamentos = new SelectList(await departamentosTask, "IdDepartamento", "Descripcion");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CrearEmpleado(CrearEmpleadoModel modelo)
    {
        if (!ModelState.IsValid)
            return View(modelo);

        var jsonEmpleado = JsonSerializer.Serialize(modelo);
        var contenido = new StringContent(jsonEmpleado, Encoding.UTF8, "application/json");

        var clienteHttp = _httpClientFactory.CreateClient();
        var mensajePeticionHttp = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7253/api/empleado/AltaEmpleado")
        {
            Content = contenido
        };

        var mensajeRespuesta = await clienteHttp.SendAsync(mensajePeticionHttp);

        if (mensajeRespuesta.IsSuccessStatusCode)
        {
            TempData["Message"] = "¡Empleado creado con éxito!!";
        }
        else
        {
            TempData["StackTrace"] = "Error en la petición HTTP con el código: " + mensajeRespuesta.StatusCode;
        }

        return RedirectToAction("Details");
    }

    private async Task<decimal> ObtenerSalarioEmpleado(HttpClient clienteHttp, int idPais, int idDepartamento, DateOnly fechaIngreso)
    {
        try
        {
            var response = await clienteHttp.GetAsync($"https://localhost:7253/api/nomina/?idPais={idPais}&idDepartamento={idDepartamento}&fechaIngreso={fechaIngreso:yyyy-MM-dd}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<string>();
                var salarioResponse = JsonSerializer.Deserialize<SalarioModel>(content);

                if (salarioResponse != null)
                {
                    return Math.Round(salarioResponse.SalarioTotal, 2);
                }

                throw new Exception("Error al deserializar la respuesta.");
            }

            throw new Exception($"Error al obtener el salario: {response.ReasonPhrase}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Exception al obtener el salario del empleado: {ex.Message}");
        }
    }


    // *-*-*-*-*-
    // | GÉNERO |
    // *-*-*-*-*-

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

    // *-*-*-*-
    // | PAÍS |
    // *-*-*-*-

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

    // *-*-*-*-*-*-*-*-
    // | DEPARTAMENTO |
    // *-*-*-*-*-*-*-*-

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

    private async Task<List<T>> ListarModelo<T>(HttpClient client, string url)
    {
        var peticion = new HttpRequestMessage(HttpMethod.Get, url)
        {
            Headers =
        {
            {"Accept", "application/json" },
            {"User-Agent", "HttpRequestsSample" }
        }
        };

        var mensajeRespuesta = await client.SendAsync(peticion);

        if (mensajeRespuesta.IsSuccessStatusCode)
        {
            string cadenaRespuesta = await mensajeRespuesta.Content.ReadFromJsonAsync<string>();
            return JsonSerializer.Deserialize<List<T>>(cadenaRespuesta);
        }
        else
        {
            TempData["StackTrace"] = "Error en la petición HTTP con el código: " + mensajeRespuesta.StatusCode;
            return new List<T>();
        }
    }
}
