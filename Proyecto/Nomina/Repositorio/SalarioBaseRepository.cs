using Nomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio;

public interface ISalarioBaseRepository
{
    decimal ObtenerSalarioBase(int idPais);
    decimal ObtenerCompensacion(int idDepartamento);
    decimal ObtenerAntiguedad(DateOnly fechaIngreso);
}
public class SalarioBaseRepository : ISalarioBaseRepository
{
    private readonly NominaContext _ctx;

    public SalarioBaseRepository(NominaContext ctx)
    {
        _ctx = ctx;
    }

    public decimal ObtenerAntiguedad(DateOnly fechaIngreso)
    {
        var aniosAntiguedad = (DateTime.Now.Year - fechaIngreso.Year);
        if (DateTime.Now.DayOfYear < fechaIngreso.DayOfYear)
        {
            aniosAntiguedad--;
        }

        return _ctx.Antiguedads
            .Where(a => a.Anios <= aniosAntiguedad)
            .OrderByDescending(a => a.Anios)
            .Select(a => a.Bono)
            .FirstOrDefault() ?? 0;

    }

    public decimal ObtenerCompensacion(int idDepartamento)
    {
        return _ctx.Compensacions
            .Where(c => c.IdDepartamento == idDepartamento)
            .Select(c => c.Multiplicador)
            .FirstOrDefault() ?? 0;
    }

    public decimal ObtenerSalarioBase(int idPais)
    {
        return _ctx.SalarioBases
            .Where(s => s.IdPais == idPais)
            .Select(s => s.Salario)
            .FirstOrDefault() ?? 0;
    }
}
