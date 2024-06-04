using System.Text.Json;

namespace Servicio
{
    public interface IEmpleadoService
    {
        public Task<string> GetEmpleadoAsync();
    }

    public class EmpleadoService : IEmpleadoService
    {
        private readonly HttpClient _httpClient;

        public EmpleadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetEmpleadoAsync()
        {
            var response = await _httpClient.GetAsync($"http://localhost:7252/api/empleado/");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var empleado = JsonSerializer.Deserialize<string>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return empleado;
        }
    }
}
