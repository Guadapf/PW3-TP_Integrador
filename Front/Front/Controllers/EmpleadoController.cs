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

            Console.WriteLine(jsonEmpleado);

            var clienteHttp = _httpClientFactory.CreateClient();
            var mensajePeticionHttp = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7253/api/empleado")
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

        public IActionResult ListarGeneros()
        {
            List<GeneroModel> generos = new List<GeneroModel>();
            generos.Add(new GeneroModel { IdGenero = 1, Descripcion = "Masculino" });
            generos.Add(new GeneroModel { IdGenero = 2, Descripcion = "Femenino" });
            generos.Add(new GeneroModel { IdGenero = 3, Descripcion = "Otro" });
            generos.Add(new GeneroModel { IdGenero = 4, Descripcion = "más gei que eze (difícil)" });
            return View(generos);
        }

        // *-*-*-*-
        // | PAÍS |
        // *-*-*-*-

        public IActionResult ListarPaises()
        {
            List<PaisModel> paises = new List<PaisModel>();
            paises.Add(new PaisModel { IdPais = 1, Descripcion = "Argentina (namber uan)" });
            paises.Add(new PaisModel { IdPais = 2, Descripcion = "República Popular China" });
            paises.Add(new PaisModel { IdPais = 3, Descripcion = "Unión de Repúblicas Socialistas Soviéticas" });
            return View(paises);
        }

        // *-*-*-*-*-*-*-*-
        // | DEPARTAMENTO |
        // *-*-*-*-*-*-*-*-

        public IActionResult ListarDepartamentos()
        {
            List<DepartamentoModel> departamentos = new List<DepartamentoModel>();
            departamentos.Add(new DepartamentoModel { IdDepartamento = 1, Descripcion = "La Matanza" });
            departamentos.Add(new DepartamentoModel { IdDepartamento = 2, Descripcion = "Esquel" });
            return View(departamentos);
        }
    }

}
