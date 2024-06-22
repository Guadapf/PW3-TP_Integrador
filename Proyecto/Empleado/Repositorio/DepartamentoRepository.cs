using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio;

public interface IDepartamentoRepository
{
    Task AddDepartamento(Departamento departamento);
    Task<List<Departamento>> GetDepartamentos();
}

public class DepartamentoRepository : IDepartamentoRepository
{
    private EmpleadoContext _ctx { get; set; }

    public DepartamentoRepository(EmpleadoContext empleadoContext)
    {
        _ctx = empleadoContext;
    }

    public async Task AddDepartamento(Departamento departamento)
    {
        await _ctx.AddAsync(departamento);
        await _ctx.SaveChangesAsync();
    }

    public async Task<List<Departamento>> GetDepartamentos()
    {
        return await _ctx.Departamentos.Select(d => new Departamento
        {
            IdDepartamento = d.IdDepartamento,
            Descripcion = d.Descripcion
        }).ToListAsync();
    }
}
