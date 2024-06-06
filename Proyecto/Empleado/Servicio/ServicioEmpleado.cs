using Entidades;
using Repositorio;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Servicio;

public interface IEmpleadoService
{
    Task cargarEmpleado(Empleado empleado);
    Task<string> ObtenerEmpleados();
    Task ActualizarEmpleado(Empleado empleado);
    Task EliminarEmpleado(int idEmpleado);
    Task<string> ObtenerEmpleadoPorId(int idEmpleado);
}

public class ServicioEmpleado : IEmpleadoService
{
    private IEmpleadoRepository _empleadoRepository;

    public ServicioEmpleado(IEmpleadoRepository empleadoRepository)
    {
        _empleadoRepository = empleadoRepository;
    }

    public async Task ActualizarEmpleado(Empleado empleado)
    {
        if(empleado != null)
        {
            await _empleadoRepository.UpdateEmpleado(empleado);
        }
    }

    public async Task cargarEmpleado(Empleado empleado) {
        empleado.IdEmpleado = await BuscarUltimoId();
       await _empleadoRepository.AddEmpleado(empleado);
    }

    private async Task<int> BuscarUltimoId()
    {
        var empleados = await _empleadoRepository.GetEmpleados();
        var ultimoId = empleados.Count == 0 ? 0 : empleados.Max(e => e.IdEmpleado);
        int nuevoId = ultimoId + 1;
        return nuevoId;
    }
    public async Task<string> ObtenerEmpleadoPorId(int idEmpleado)
    {
        var empleado = await _empleadoRepository.GetEmpleadoById(idEmpleado);
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        string jsonString = JsonSerializer.Serialize(empleado, opciones);
        return jsonString;
    }

    public async Task EliminarEmpleado(int idEmpleado)
    {
        var empleado = await ObtenerEmpleadoPorId(idEmpleado);
        if(empleado != null)
        {
            await _empleadoRepository.DeleteEmpleado(idEmpleado);
        }
    }


    public async Task<string> ObtenerEmpleados()
    {
        var listaEmpleados = await _empleadoRepository.GetEmpleados();
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        string jsonString = JsonSerializer.Serialize(listaEmpleados, opciones);
        return jsonString;
    }
}
