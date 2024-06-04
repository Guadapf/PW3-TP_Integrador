using System.Net.Http;
using System.Text.Json;

namespace Servicio
{
    public interface IEmpleadoService
    {
        public Task<string> GetEmpleadoAsync();
    }

    public class EmpleadoService : IEmpleadoService
    {
        private readonly IHttpClientFactory _httpClient;

        public EmpleadoService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetEmpleadoAsync()
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                "https://localhost:7253/api/empleado")
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
                var empleado = JsonSerializer.Deserialize<string>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return empleado;
            }
            else
            {
                return "Sadness";
            }

            
        }
        /*
        public async Task<IActionResult> ObtenerEmpleados()
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                "https://localhost:7252/api/empleado")
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
                return Content(content, response.Content.Headers.ContentType.ToString());
            }
            else
            {
                return Content(content, "mission failed, we'll get 'em next time");
            }*/

        }
    }
//}
