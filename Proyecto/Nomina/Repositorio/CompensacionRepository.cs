using Microsoft.EntityFrameworkCore;
using Nomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio;

public interface ICompensacionRepository
{
    Task<decimal> ObtenerCompensacion(int idDepartamento);
    Task<List<Compensacion>> ObtenerCompensaciones();
    Task AgregarCompensacion(Compensacion compensacion);
}
public class CompensacionRepository : ICompensacionRepository
{
    private readonly NominaContext _ctx;

    public CompensacionRepository(NominaContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<decimal> ObtenerCompensacion(int idDepartamento)
    {
        return await _ctx.Compensacions
            .Where(c => c.IdDepartamento == idDepartamento)
            .Select(c => c.Multiplicador)
            .FirstOrDefaultAsync() ?? 0;
    }

    public async Task<List<Compensacion>> ObtenerCompensaciones()
    {
        return await _ctx.Compensacions
            .ToListAsync();
    }

    public async Task AgregarCompensacion(Compensacion compensacion)
    {
        await _ctx.Compensacions.AddAsync(compensacion);
        await _ctx.SaveChangesAsync();
    }
}
