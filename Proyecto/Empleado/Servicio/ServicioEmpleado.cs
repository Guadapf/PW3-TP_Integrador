using Entidades;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Servicio;

public interface IEmpleadoService
{
    public void cargarEmpleado();
    string ObtenerEmpleados();
}

public class ServicioEmpleado : IEmpleadoService
{
    private static List<Empleado> _empleado = new List<Empleado>();

    public void cargarEmpleado() {
        new Empleado
        {
            idEmpleado = 1,
            Nombre = "Juan Perez"
        };

    }

    public string ObtenerEmpleados()
    {
        //------------------------------
        // Reemplazar por algo dinámico
        //------------------------------
        var empleado1 = new Empleado
        {
            idEmpleado = 01,
            Nombre = "Juan Pérez",
            Edad = 39
        };
        var empleado2 = new Empleado
        {
            idEmpleado = 02,
            Nombre = "Juana Pereza",
            Edad = 93
        };
        var listaEmpleados = new List<Empleado>();
        listaEmpleados.Add(empleado1);
        listaEmpleados.Add(empleado2);
        //------------------------------
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        string jsonString = JsonSerializer.Serialize(listaEmpleados, opciones);
        return jsonString;
    }
}
