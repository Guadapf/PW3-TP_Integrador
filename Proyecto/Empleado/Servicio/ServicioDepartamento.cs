using System.Text.Json;
using System.Text.Json.Serialization;
using Entidades;
using Repositorio;

namespace Servicio;

public interface IServicioDepartamento
{
    Task cargarDepartamento(Departamento departamento);
    Task<string> ObtenerDepartamentos();
}

public class ServicioDepartamento : IServicioDepartamento
{
    private IDepartamentoRepository _departamentoRepository;

    public ServicioDepartamento(IDepartamentoRepository departamentoRepository)
    {
        _departamentoRepository = departamentoRepository;
    }

    public async Task cargarDepartamento(Departamento departamento)
    {
        await _departamentoRepository.AddDepartamento(departamento);
    }

    public async Task<string> ObtenerDepartamentos()
    {
        var departamentos = await _departamentoRepository.GetDepartamentos();
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        string jsonString = JsonSerializer.Serialize(departamentos, opciones);
        return jsonString;
    }
}
