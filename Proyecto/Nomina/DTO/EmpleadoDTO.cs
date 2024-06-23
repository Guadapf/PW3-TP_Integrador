using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO;

public class EmpleadoDTO
{
    public int IdEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public int IdDepartamento { get; set; }
    public int IdPais { get; set; }
    public decimal Salario { get; set; }
}
