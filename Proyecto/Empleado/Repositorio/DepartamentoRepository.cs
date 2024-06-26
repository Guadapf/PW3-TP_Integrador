using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio;

public interface IDepartamentoRepository
{
    Task<int> AddDepartamento(Departamento departamento);
    Task<List<Departamento>> GetDepartamentos();
}

public class DepartamentoRepository : IDepartamentoRepository
{
    private EmpleadoContext _ctx { get; set; }

    public DepartamentoRepository(EmpleadoContext empleadoContext)
    {
        _ctx = empleadoContext;
    }

    public async Task<int> AddDepartamento(Departamento departamento)
    {
        await _ctx.AddAsync(departamento);
        await _ctx.SaveChangesAsync();
        return departamento.IdDepartamento;
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
