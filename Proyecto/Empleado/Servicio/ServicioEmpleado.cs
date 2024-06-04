using Entidades;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Servicio
{
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
            return "a";
        }
    }
}
