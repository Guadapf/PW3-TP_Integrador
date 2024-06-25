using Microsoft.EntityFrameworkCore;
using Nomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio;

public interface ISalarioBaseRepository
{
    Task<decimal> ObtenerSalarioBase(int idPais);
    Task<List<SalarioBase>> ObtenerSalariosBase();
    Task AgregarSalarioBase(SalarioBase salarioBase);

}
public class SalarioBaseRepository : ISalarioBaseRepository
{
    private readonly NominaContext _ctx;

    public SalarioBaseRepository(NominaContext ctx)
    {
        _ctx = ctx;
    }

    public async Task AgregarSalarioBase(SalarioBase salarioBase)
    {
        await _ctx.SalarioBases.AddAsync(salarioBase);
        await _ctx.SaveChangesAsync();
    }

    public async Task<decimal> ObtenerSalarioBase(int idPais)
    {
        return await _ctx.SalarioBases
            .Where(s => s.IdPais == idPais)
            .Select(s => s.Salario)
            .FirstOrDefaultAsync() ?? 0;
    }

    public async Task<List<SalarioBase>> ObtenerSalariosBase()
    {
        return await _ctx.SalarioBases
            .ToListAsync();
    }
}
