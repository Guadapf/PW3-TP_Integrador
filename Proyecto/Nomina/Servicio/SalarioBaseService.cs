using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Servicio;

public interface ISalarioBaseService
{
    string CalcularSalario(int idPais, int idDepartamento, DateOnly fechaIngreso);
}
public class SalarioBaseService : ISalarioBaseService
{
   private readonly ISalarioBaseRepository _salarioBaseRepository;

    public SalarioBaseService(ISalarioBaseRepository salarioBaseRepository)
    {
        _salarioBaseRepository = salarioBaseRepository;
    }

    public string CalcularSalario(int idPais, int idDepartamento, DateOnly fechaIngreso)
    {
        var salarioBase = _salarioBaseRepository.ObtenerSalarioBase(idPais);
        var compensacion = _salarioBaseRepository.ObtenerCompensacion(idDepartamento);
        var antiguedad = _salarioBaseRepository.ObtenerAntiguedad(fechaIngreso);

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
}
