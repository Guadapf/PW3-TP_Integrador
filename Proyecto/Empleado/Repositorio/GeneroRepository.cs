using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio;

public interface IGeneroRepository
{
    Task<List<Genero>> GetGeneros();
}

public class GeneroRepository : IGeneroRepository
{
    private EmpleadoContext _ctx { get; set; }

    public GeneroRepository(EmpleadoContext empleadoContext)
    {
        _ctx = empleadoContext;
    }

    public async Task<List<Genero>> GetGeneros()
    {
        return await _ctx.Generos.Select(g => new Genero
            {
                IdGenero = g.IdGenero,
                Descripcion = g.Descripcion
            })
            .ToListAsync();
    }
}
