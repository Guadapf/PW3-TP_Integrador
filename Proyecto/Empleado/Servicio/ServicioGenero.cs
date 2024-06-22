using System.Text.Json.Serialization;
using System.Text.Json;
using Repositorio;
using Entidades;

namespace Servicio;

public interface IServicioGenero
{
    Task cargarGenero(Genero genero);
    Task<string> ObtenerGeneros();
}

public class ServicioGenero : IServicioGenero
{
    private IGeneroRepository _generoRepository;

    public ServicioGenero(IGeneroRepository generoRepository)
    {
        _generoRepository = generoRepository;
    }

    public async Task cargarGenero(Genero genero)
    {
        await _generoRepository.AddGenero(genero);
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
