using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio;

public interface IPaiRepository
{
    Task AddPai(Pai pais);
    Task<List<Pai>> GetPaises();
}

public class PaiRepository : IPaiRepository
{
    private EmpleadoContext _ctx { get; set; }

    public PaiRepository(EmpleadoContext empleadoContext)
    {
        _ctx = empleadoContext;
    }

    public async Task AddPai(Pai pais)
    {
        await _ctx.AddAsync(pais);
        await _ctx.SaveChangesAsync();
    }

    public async Task<List<Pai>> GetPaises()
    {
        return await _ctx.Pais.Select(p => new Pai
        {
            IdPais = p.IdPais,
            Descripcion = p.Descripcion
        }).ToListAsync();
    }
}
