using System.Text.Json.Serialization;
using System.Text.Json;
using Repositorio;

namespace Servicio;

public interface IServicioGenero
{
    Task<string> ObtenerGeneros();
}

public class ServicioGenero : IServicioGenero
{
    private IGeneroRepository _generoRepository;

    public ServicioGenero(IGeneroRepository generoRepository)
    {
        _generoRepository = generoRepository;
    }

    public async Task<string> ObtenerGeneros()
    {
        var generos = await _generoRepository.GetGeneros();
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        string jsonString = JsonSerializer.Serialize(generos, opciones);
        return jsonString;
    }
}
