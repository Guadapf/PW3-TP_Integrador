using Front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Servicio;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Front.Controllers
{
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
            
            // Crear petición
            var mensajePeticionHttp = new HttpRequestMessage(
                HttpMethod.Get,
                "https://localhost:7253/api/empleado/GetEmpleados")
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
            List<EmpleadoModel> listaEmpleados = new List<EmpleadoModel>();

            if (mensajeRespuesta.IsSuccessStatusCode)
            {
                try
                {
                    string cadenaRespuesta = await mensajeRespuesta.Content.ReadFromJsonAsync<string>();

                    if (!string.IsNullOrEmpty(cadenaRespuesta))
                    {
                        listaEmpleados = JsonSerializer.Deserialize<List<EmpleadoModel>>(cadenaRespuesta);

                        if (listaEmpleados == null || listaEmpleados.Count == 0)
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

            return View(listaEmpleados);
        }

        public IActionResult CrearEmpleado()
        {
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
                Console.WriteLine("Empleado created successfully!");
            }
            else
            {
                Console.WriteLine("HTTP request failed with status code: " + mensajeRespuesta.StatusCode);
            }

            return RedirectToAction("Details");
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
                TempData["Message"] = "Empleado created successfully!";
            }
            else
            {
                TempData["StackTrace"] = "HTTP request failed with status code: " + mensajeRespuesta.StatusCode;
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
                TempData["Message"] = "Empleado created successfully!";
            }
            else
            {
                TempData["StackTrace"] = "HTTP request failed with status code: " + mensajeRespuesta.StatusCode;
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
                TempData["Message"] = "Empleado created successfully!";
            }
            else
            {
                TempData["StackTrace"] = "HTTP request failed with status code: " + mensajeRespuesta.StatusCode;
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

}
