using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio;

public interface ISalarioBaseService
{
    decimal CalcularSalario(int idPais, int idDepartamento, DateOnly fechaIngreso);
}
public class SalarioBaseService : ISalarioBaseService
{
   private readonly ISalarioBaseRepository _salarioBaseRepository;

    public SalarioBaseService(ISalarioBaseRepository salarioBaseRepository)
    {
        _salarioBaseRepository = salarioBaseRepository;
    }

    public decimal CalcularSalario(int idPais, int idDepartamento, DateOnly fechaIngreso)
    {
        var salarioBase = _salarioBaseRepository.ObtenerSalarioBase(idPais);
        var compensacion = _salarioBaseRepository.ObtenerCompensacion(idDepartamento);
        var antiguedad = _salarioBaseRepository.ObtenerAntiguedad(fechaIngreso);

        return (salarioBase * compensacion) + antiguedad;
    }
}
