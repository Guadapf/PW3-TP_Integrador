using Nomina;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Servicio;

public interface ICompensacionService
{
    Task<decimal> ObtenerCompensacion(int idDepartamento);
    Task<string> ObtenerCompensaciones();
}
public class CompensacionService : ICompensacionService
{
    private readonly ICompensacionRepository _compensacionRepository;

    public CompensacionService(ICompensacionRepository compensacionRepository)
    {
        _compensacionRepository = compensacionRepository;
    }

    public async Task<decimal> ObtenerCompensacion(int idDepartamento)
    {
        return await _compensacionRepository.ObtenerCompensacion(idDepartamento);
    }

    public async Task<string> ObtenerCompensaciones()
    {
        var listaCompensaciones = await _compensacionRepository.ObtenerCompensaciones();
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        string jsonString = JsonSerializer.Serialize(listaCompensaciones, opciones);
        return jsonString;
    }
}
