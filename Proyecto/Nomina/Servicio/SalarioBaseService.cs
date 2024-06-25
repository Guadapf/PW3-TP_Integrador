using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Nomina;

namespace Servicio;

public interface ISalarioBaseService
{
    Task<string> CalcularSalario(int idPais, int idDepartamento, DateOnly fechaIngreso);
    Task<string> ObtenerSalariosBase();
    Task AgregarSalarioBase(SalarioBase salarioBase);
}
public class SalarioBaseService : ISalarioBaseService
{
    private readonly ISalarioBaseRepository _salarioBaseRepository;
    private readonly IAntiguedadService _antiguedadService;
    private readonly ICompensacionService _compensacionService;

    public SalarioBaseService(ISalarioBaseRepository salarioBaseRepository, IAntiguedadService antiguedadService, ICompensacionService compensacionService)
    {
        _salarioBaseRepository = salarioBaseRepository;
        _antiguedadService = antiguedadService;
        _compensacionService = compensacionService;
    }

    public async Task AgregarSalarioBase(SalarioBase salarioBase)
    {
        await _salarioBaseRepository.AgregarSalarioBase(salarioBase);
    }

    public async Task<string> CalcularSalario(int idPais, int idDepartamento, DateOnly fechaIngreso)
    {
        var salarioBase = await _salarioBaseRepository.ObtenerSalarioBase(idPais);
        var compensacion = await _compensacionService.ObtenerCompensacion(idDepartamento);
        var antiguedad = await _antiguedadService.ObtenerAntiguedad(fechaIngreso);

        var salario = (salarioBase * compensacion) + antiguedad;
        var resultado = new
        {
            SalarioBase = salarioBase,
            Compensacion = compensacion,
            Antiguedad = antiguedad,
            SalarioTotal = salario
        };

        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        string jsonString = JsonSerializer.Serialize(resultado, opciones);
        return jsonString;
    }

    public async Task<string> ObtenerSalariosBase()
    {
        var listaSalariosBase = await _salarioBaseRepository.ObtenerSalariosBase();
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        string jsonString = JsonSerializer.Serialize(listaSalariosBase, opciones);
        return jsonString;
    }
}
