using Microsoft.EntityFrameworkCore;
using Nomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio;

public interface IAntiguedadRepository
{
    Task<decimal> ObtenerAntiguedad(DateOnly fechaIngreso);
    Task<List<Antiguedad>> ObtenerAntiguedades();
    Task AgregarAntiguedad(Antiguedad antiguedad);

}
public class AntiguedadRepository : IAntiguedadRepository
{
    private readonly NominaContext _ctx;

    public AntiguedadRepository(NominaContext ctx)
    {
        _ctx = ctx;
    }

    public async Task AgregarAntiguedad(Antiguedad antiguedad)
    {
        await _ctx.Antiguedads.AddAsync(antiguedad);
        await _ctx.SaveChangesAsync();
    }

    public async Task<decimal> ObtenerAntiguedad(DateOnly fechaIngreso)
    {
        var aniosAntiguedad = (DateTime.Now.Year - fechaIngreso.Year);
        if (DateTime.Now.DayOfYear < fechaIngreso.DayOfYear)
        {
            aniosAntiguedad--;
        }

        return await _ctx.Antiguedads
            .Where(a => a.Anios <= aniosAntiguedad)
            .OrderByDescending(a => a.Anios)
            .Select(a => a.Bono)
            .FirstOrDefaultAsync() ?? 0;

    }

    public async Task<List<Antiguedad>> ObtenerAntiguedades()
    {
        return await _ctx.Antiguedads
            .ToListAsync();
    }
}
