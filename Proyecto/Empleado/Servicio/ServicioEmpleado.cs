using Entidades;
using Repositorio;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Servicio;

public interface IEmpleadoService
{
    Task cargarEmpleado(Empleado empleado);
    Task<string> ObtenerEmpleados();
    Task ActualizarEmpleado(Empleado empleado);
    Task EliminarEmpleado(int idEmpleado);
    Task<string> ObtenerEmpleadoPorId(int idEmpleado);
    Task<string> ObtenerEmpleadosPorParam(string busqueda);
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
       await _empleadoRepository.AddEmpleado(empleado);
    }

    public async Task<string> ObtenerEmpleadoPorId(int idEmpleado)
    {
        var empleado = await _empleadoRepository.GetEmpleadoById(idEmpleado);
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        string jsonString = JsonSerializer.Serialize(empleado, opciones);
        return jsonString;
    }

    public async Task<string> ObtenerEmpleadosPorParam(string busqueda)
    {
        var empleados = await _empleadoRepository.GetEmpleadosByParam(busqueda);
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        string jsonString = JsonSerializer.Serialize(empleados, opciones);
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
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        string jsonString = JsonSerializer.Serialize(listaEmpleados, opciones);
        return jsonString;
    }
}
