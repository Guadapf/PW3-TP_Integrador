using System.Text.Json;
using System.Text.Json.Serialization;
using Repositorio;

namespace Servicio;

public interface IServicioPai
{
    Task<string> ObtenerPaises();
}

public class ServicioPai : IServicioPai
{
    private IPaiRepository _paiRepository;

    public ServicioPai(IPaiRepository paiRepository)
    {
        _paiRepository = paiRepository;
    }

    public async Task<string> ObtenerPaises()
    {
        var paises = await _paiRepository.GetPaises();
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        string jsonString = JsonSerializer.Serialize(paises, opciones);
        return jsonString;
    }
}
