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

public interface IAntiguedadService
{
    Task<decimal> ObtenerAntiguedad(DateOnly fechaIngreso);
    Task<string> ObtenerAntiguedades();
    Task AgregarAntiguedad(Antiguedad antiguedad);
}
public class AntiguedadService : IAntiguedadService
{
    private readonly IAntiguedadRepository _antiguedadRepository;

    public AntiguedadService(IAntiguedadRepository antiguedadRepository)
    {
        _antiguedadRepository = antiguedadRepository;
    }

    public async Task AgregarAntiguedad(Antiguedad antiguedad)
    {
        if(antiguedad != null)
        {
            await _antiguedadRepository.AgregarAntiguedad(antiguedad);
        }
        else
        {
            throw new Exception("La antiguedad es null");
        }
    }

    public async Task<decimal> ObtenerAntiguedad(DateOnly fechaIngreso)
    {
        return await _antiguedadRepository.ObtenerAntiguedad(fechaIngreso);
    }

    public async Task<string> ObtenerAntiguedades()
    {
        var listaAntiguedades = await _antiguedadRepository.ObtenerAntiguedades();
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        string jsonString = JsonSerializer.Serialize(listaAntiguedades, opciones);
        return jsonString;
    }
}
