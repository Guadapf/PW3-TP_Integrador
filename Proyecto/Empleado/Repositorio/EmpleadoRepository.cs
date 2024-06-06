using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio;

public interface IEmpleadoRepository
{
    Task AddEmpleado(Empleado empleado);
    Task UpdateEmpleado(Empleado empleado);
    Task DeleteEmpleado(int idEmpleado);
    Task<Empleado> GetEmpleadoById(int idEmpleado);
    Task<List<Empleado>> GetEmpleados();
}
public class EmpleadoRepository : IEmpleadoRepository
{
    private EmpleadoContext _ctx { get; set; }

    public EmpleadoRepository(EmpleadoContext empleadoContext)
    {
        _ctx = empleadoContext;
    }

    public async Task AddEmpleado(Empleado empleado)
    {
       await _ctx.AddAsync(empleado);
       await _ctx.SaveChangesAsync();
    }

    public async Task UpdateEmpleado(Empleado empleado)
    {
        Empleado emp = await _ctx.Empleados.FindAsync(empleado.IdEmpleado);

        if(emp != null)
        {
            emp.Nombre = empleado.Nombre;
            emp.Apellido = empleado.Apellido;
            emp.FechaNac = empleado.FechaNac;
            emp.FechaIngreso = empleado.FechaIngreso;
            emp.IdDepartamento = empleado.IdDepartamento;
            emp.IdGenero = empleado.IdGenero;
            emp.IdPais = empleado.IdPais;
            await _ctx.SaveChangesAsync();
        }
    }

    public async Task DeleteEmpleado(int idEmpleado)
    {
        Empleado emp = await _ctx.Empleados.FindAsync(idEmpleado);

        if(emp != null)
        {
            _ctx.Empleados.Remove(emp);
            await _ctx.SaveChangesAsync();
        }
    }

    public async Task<Empleado> GetEmpleadoById(int idEmpleado)
    {
        return await _ctx.Empleados.FindAsync(idEmpleado);
    }

    public async Task<List<Empleado>> GetEmpleados()
    {
        return await _ctx.Empleados.ToListAsync();
    }
}
